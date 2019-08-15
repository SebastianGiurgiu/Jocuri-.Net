using Schelet_Server.Repository;
using Schelet_Server.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schelet_Server
{
    public class MyServer : MarshalByRefObject, ISubject
    {

        Repository<User> repouser;
        Repository<Jucator> repojucator;
        Repository<Joc> repojoc;
        Repository<JocJucator> repojocjucator;

        public MyServer(Repository<User> repouser, Repository<Jucator> repojucator,Repository<Joc> repojoc,Repository<JocJucator> repojocjucator)
        {
            this.repouser = repouser;
            this.repojucator = repojucator;
            this.repojoc = repojoc;
            this.repojocjucator = repojocjucator;
        }

        
        //===========================LOGIN============================

        public bool login(string username, string password)
        {
            try
            {
                User user = repouser.GetModelById(username);
                if (user.password.Equals(password))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        //===============================CAUT JUCATOR DUPA USERNAME========================

        public Jucator findJucator(string username)
        {
            foreach(var juc in repojucator.GetModel())
            {
                if (juc.username.Equals(username))
                {
                    return juc;
                }
            }

            return null;
        }
        //================================CAUT UN JUCATOR DUPA ID============================
        public Jucator findJucatorId(int id)
        {
            return repojucator.GetModelById(id);
        }
        //================================CAUT UN JOC DUPA ID=======================
        public Joc findJoc(int id)
        {
            return repojoc.GetModelById(id);
        }
        //============================CAUT JOC-JUCATOR DUPA IDJOC SI IDJUCATOR==========
        public JocJucator findJucatorInJoc(int idJoc, int idJucator)
        {
            foreach (var jj in repojocjucator.GetModel())
            {
                if (jj.idjoc == idJoc && jj.idjucator == idJucator)
                    return jj;
            }

            return null;
        }

        public JocJucator findAdversar(int idJoc,int idJucator)
        {
            foreach (var jj in repojocjucator.GetModel())
            {
                if (jj.idjoc == idJoc && jj.idjucator != idJucator)
                    return jj;
            }

            return null;
        }


        //=====================RETURNEZ LISTA JUCATORI DINTR-UN JOC========== POSBIL NEIMPORTANT
        public List<Jucator> getListaJucatori(int idJoc)
        {
            List<Jucator> list = new List<Jucator>();

            foreach (var jj in repojocjucator.GetModel())
            {
                if (jj.idjoc == idJoc)
                {
                    list.Add(repojucator.GetModelById(jj.idjucator.Value));
                }
            }

            return list;
        }

        //======================RETURNEZ TOTI JOC-JUCATORII DINTR-UN JOC =========== FOAAAAAAAAAAAAAAAAARTE IMPORTANT
        public List<JocJucator> getListaJocJucatori(int idJoc)
        {
            List<JocJucator> list = new List<JocJucator>();
            List<JocJucator> listamare = (List<JocJucator>)repojocjucator.GetModel();

            foreach (var jj in listamare)
            {
                if (jj.idjoc == idJoc)
                {
                    list.Add(jj);
                }
            }

            return list;
        }
        //======================RETURNEZ TOTI JOC-JUCATORII (ADVERSARIII) DINTR-UN JOC =========== FOAAAAAAAAAAAAAAAAARTE IMPORTANT
        public List<JocJucator> getAdversari(int idJoc,int idJucator)
        {
            List<JocJucator> list = new List<JocJucator>();
            List<JocJucator> listamare = (List<JocJucator>)repojocjucator.GetModel();

            foreach (var jj in listamare)
            {
                if (jj.idjoc == idJoc && jj.idjucator!=idJucator)
                {
                    list.Add(jj);
                }
            }

            return list;

        }

        //===========CREEZ JOC ============ AI GRIJA LA ATRIBUTE
        public Joc creareJoc()
        {
            Joc joc = new Joc
            {
                castigator = -1,
                rand = 1
                
            };

            repojoc.InsertModel(joc);
            repojoc.Save();

            return joc;

        }

        //===========CREEZ JOC-JUCATORII PARTICIPANTI LA UN JOC ============ AI GRIJA LA ATRIBUTE
        public void creareJocJucator(List<Jucator> jucators, Joc joc)
        {
            foreach (var juc in jucators)
            {
                JocJucator jj = new JocJucator
                {
                    idjoc = joc.id,
                    idjucator = juc.id,
                    sirprimit="_________",
                    pozcurenta=-1,
                    ales = 0

                };
                repojocjucator.InsertModel(jj);
                repojocjucator.Save();

            }

        }


        public int generaresalt(Joc joc,Jucator jucator)
        {
            Random rand = new Random();
            int x = rand.Next(1,3);

            JocJucator jj = findJucatorInJoc(joc.id, jucator.id);
            JocJucator adversar = findAdversar(joc.id, jucator.id);

            int pozcurent = jj.pozcurenta.Value;
            pozcurent += x;
            string sirnou ="";

            if (jj.idjucator == 1)
            {

                for (int i = 0; i < 9; i++)
                {
                    if (i == pozcurent)
                        sirnou += "C";
                    else
                    {
                        if (i == adversar.pozcurenta)
                        {
                            sirnou += "D";
                        }
                       
                        else 
                            if (jj.sirprimit[i] != 'C' && jj.sirprimit[i]!='D')
                            {
                                sirnou += jj.sirprimit[i];
                            }
                        else
                        {
                            sirnou += "_";
                        }
                    }


                }
            }

            else
            {
                for (int i = 0; i < 9; i++)
                {
                    if (i == pozcurent)
                        sirnou += "D";
                    else
                    {
                        if (i == adversar.pozcurenta)
                        {
                            sirnou += "C";
                        }

                        else if (jj.sirprimit[i] != 'D' && jj.sirprimit[i] != 'C')
                        {
                            sirnou += jj.sirprimit[i];
                        }
                        else
                        {
                            sirnou += "_";
                        }
                    }

                 
                }
            }

            int ales = jj.ales.Value;
            ales += 1;

            jj.pozcurenta = pozcurent;
            jj.sirprimit = sirnou;
            jj.ales=ales;

            adversar.sirprimit = sirnou;

            repojocjucator.UpdateModel(adversar);
            repojocjucator.UpdateModel(jj);



            Joc j = repojoc.GetModelById(joc.id);
            if (j.rand != getListaJocJucatori(joc.id).Count)
            {
                j.rand += 1;
            }
            else
            {
                j.rand = 1;
            }
            repojoc.UpdateModel(j);




            return x;

        }

        public List<int> getListiduri(Joc joc)
        {
            List<int> iduri = new List<int>();
            iduri.Add(0);
            List<JocJucator> list = getListaJocJucatori(joc.id);

            foreach(var jj in list)
            {
                iduri.Add(jj.idjucator.Value);
            }

            return iduri;

        }


        public int getRand(Joc joc)
        {
            return repojoc.GetModelById(joc.id).rand.Value;
        }



        public void GenerareSir(Joc joc,Jucator jucator)
        {

            JocJucator jj = findJucatorInJoc(joc.id, jucator.id);

            if (!jj.sirprimit.Contains("X"))
            {
                Random rand = new Random();
                int x = rand.Next(9);
                string sir = "";

                for (int i = 0; i < 9; i++)
                    if (i == x)
                        sir += "X";
                    else
                        sir += "_";

                jj.sirprimit = sir;


                repojocjucator.UpdateModel(jj);


                JocJucator j2 = findAdversar(joc.id, jucator.id);

                j2.sirprimit = sir;
                repojocjucator.UpdateModel(j2);


            }

        }



        public int Castigat(Joc joc)
        {
            int max = -1;
            int castigator = -1;


            List<JocJucator> list = getListaJocJucatori(joc.id);
            foreach (var jj in list)
            {
                if (jj.pozcurenta > max)
                {
                    max = jj.pozcurenta.Value;
                    castigator = jj.idjucator.Value;

                }

            }

            Joc j = repojoc.GetModelById(joc.id);
            j.castigator = castigator;
            repojoc.UpdateModel(j);

            return castigator;

        }


        public bool Gata(Joc joc)
        {

            List<JocJucator> list = getListaJocJucatori(joc.id);

            if (list[0].ales == 3 && list[1].ales == 3)
                return true;

            return false;
        }

      


     

        //public JocJucator CelMaiBun(Joc joc)
        //{
        //    JocJucator castigator=null;
        //    int max=0;

        //    List<JocJucator> list = getListaJocJucatori(joc.id);

        //    foreach(var jj in list)
        //    {
        //        if (jj.punctaj > max)
        //        {
        //            max = jj.punctaj.Value;
        //            castigator = jj;

        //        }
        //    }

        //    Joc jocfinal = repojoc.GetModelById(joc.id);
        //    jocfinal.castigator = castigator.idjucator;
        //    jocfinal.punctecastigator = castigator.punctaj;
        //    repojoc.UpdateModel(jocfinal);

        //    return castigator;

        //}

     
            //====================ACTUALIZEZ URMATORUL LABEL-UL CARE IMI ARATA CINE URMEAZA 
            public int LaRand(Joc joc)
            {
            List<JocJucator> list = getListaJocJucatori(joc.id);

            foreach(var jj in list)
            {
                if (PoateGhicii(joc, jj.idjucator.Value))
                {
                    return jj.idjucator.Value;
                }
            }

            return 0;

            }

          //====================VERIFIC DACA TOTI AU ALES INTR-UN JOC
        public void TotiAuAles(Joc joc)
        {
            List<JocJucator> list = getListaJocJucatori(joc.id);
            bool res = true;

            foreach (var jj in list)
            {
                if (jj.ales == 0)
                {
                    res = false;
                }
            }

            if (res == true)
            {
                foreach (var jj in list)
                {
                    jj.ales = 0;
                    repojocjucator.UpdateModel(jj);
                }

            }

        }


        //=============VERIFIF DACA UN JUCATOR POATE SA FACA O ACTIUNEEE
        public bool PoateGhicii(Joc joc, int Idjucator)
        {
            TotiAuAles(joc);
            JocJucator jj = findJucatorInJoc(joc.id, Idjucator);
            if (jj.ales == 0)
            {
                jj.ales = 1;
                repojocjucator.UpdateModel(jj);
                return true;
            }

            return false;

        }


 
        private IList<IObserver> observers = new List<IObserver>();

        private IList<IObserver> standby = new List<IObserver>();




        public void FinalJoc()
        {
            observers.Clear();
            
        }

        
        public IList<IObserver> SePoateIncepeJoc()
        {
            return standby;
        }



        public IList<IObserver> AlegereJucatori() {
            foreach(var ob in standby)
            {
                observers.Add(ob);
            }

            standby.Clear();

            return observers;
        }


        public void AddObserver(IObserver observer)
        {
            // observers.Add(observer);
            standby.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.update();
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
    }
}
