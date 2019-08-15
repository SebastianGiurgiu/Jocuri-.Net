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
                    return repojocjucator.GetModelById(jj.id);
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
                carticastigator="",
                listcartidisponibi="1234",
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
                    carte="",
                    casticastigate="",
                    ales=0                   

                };
                repojocjucator.InsertModel(jj);
                repojocjucator.Save();

            }

        }

        public void AlegeCarte(Joc joc,Jucator jucator,string carte)
        {
            JocJucator jocJucator = findJucatorInJoc(joc.id, jucator.id);
            jocJucator.carte = carte;
            jocJucator.ales = 1;


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

            repojocjucator.UpdateModel(jocJucator);

        }


        public int getRand(Joc joc)
        {
            return repojoc.GetModelById(joc.id).rand.Value;
        }



        public String ToateCartileJucatorilor(Joc joc)
        {
            List<JocJucator> list = getListaJocJucatori(joc.id);
            string toatecartile = "";

            foreach(var jj in list)
            {
                toatecartile += jj.carte;
                jj.carte = "";
                jj.ales = 0;
                repojocjucator.UpdateModel(jj);
            }

            return toatecartile;

        }


        public bool AreCarte(Joc joc,Jucator jucator)
        {

            JocJucator jj = findJucatorInJoc(joc.id, jucator.id);

            if (jj.carte.Equals(""))
                return false;

            return true;

        }

        public bool TotiAuAles2(Joc joc)
        {
            List<JocJucator> list = getListaJocJucatori(joc.id);

            foreach(var jj in list)
            {
                if (jj.ales == 0)
                    return false;
            }

            return true;

        }



        public int CelMaiBun(Joc joc)
        {
            int max = -1;
            int idcastigator = -1;

            List<JocJucator> list = getListaJocJucatori(joc.id);

            foreach (var jj in list)
            {
                int scor = jj.casticastigate.Count();
                if (scor > max)
                {
                    max = scor;
                    idcastigator = jj.idjucator.Value;

                }
            }
            Joc j = findJoc(joc.id);
            j.castigator = idcastigator;
            j.carticastigator = findJucatorInJoc(j.id, idcastigator).casticastigate;
            repojoc.UpdateModel(j);

            return idcastigator;
        }


        public void Concurs(Joc joc)
        {

            int max = -1;
            int idjcastigator=-1;
            bool maimulti = false;

            List<JocJucator> list =getListaJocJucatori(joc.id);

            foreach(var jj in list)
            {
                int scor = Convert.ToInt32(jj.carte.ToString());
                if (scor > max)
                {
                    max = scor;
                    idjcastigator = jj.idjucator.Value;

                }
                else if (scor == max)
                {
                    maimulti = true;
                }
            }

            if (maimulti == false)
            {


                JocJucator jj = findJucatorInJoc(joc.id, idjcastigator);
                string castigate = jj.casticastigate;
                castigate += ToateCartileJucatorilor(joc);
                jj.casticastigate = castigate;
                repojocjucator.UpdateModel(jj);


                Joc j = findJoc(joc.id);
                String cartile="";
                foreach(var c in j.listcartidisponibi)
                {
                    if (!jj.casticastigate.Contains(c))
                    {
                        cartile += c;
                    }
                }
               // cartile.Remove(1);
                j.listcartidisponibi = cartile;
                repojoc.UpdateModel(j);
            }
            
           
            foreach(var jj in getListaJocJucatori(joc.id))
              {
                jj.carte = "";
                jj.ales = 0;
                repojocjucator.UpdateModel(jj);
                }
            
           

        }


        public bool FinalJoc(Joc joc)
        {
            if (repojoc.GetModelById(joc.id).listcartidisponibi.Equals(""))
                return true;

            return false;
        }






        public List<String> generarecartiServer(int idJoc)
        {


            
            String posbilitati = findJoc(idJoc).listcartidisponibi;

            

            List<String> res = new List<string>();

            if (posbilitati.Count() > 0)
            {

                Random rand = new Random();

                List<int> listNumbers = new List<int>();
                int number;
                for (int i = 0; i < 2; i++)
                {
                    do
                    {
                        number = rand.Next(0, posbilitati.Count());
                    } while (listNumbers.Contains(number));
                    listNumbers.Add(number);
                }


                foreach (var i in listNumbers)
                {
                    res.Add(posbilitati[i].ToString());
                }
            }
            return res;

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
