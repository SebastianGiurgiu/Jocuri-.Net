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

        Repository<Users> repouser;
        Repository<Jucator> repojucator;
        Repository<Joc> repojoc;
        Repository<JocJucator> repojocjucator;

        public MyServer(Repository<Users> repouser, Repository<Jucator> repojucator,Repository<Joc> repojoc,Repository<JocJucator> repojocjucator)
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
                Users user = repouser.GetModelById(username);
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

        public JocJucator findAdversar(int idJoc, int idJucator)
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
                    poz1 = -1,
                    poz2=-1,
                    pozaleasa=-1,
                    ales = 0

                };
                repojocjucator.InsertModel(jj);
                repojocjucator.Save();

            }

        }

        //=================== RETURNEZ LISTA DE ID-URI CA SA MA AJUT LA ASTEPTAREA ALTOR JUCATORI 
        public List<int> getListiduri(Joc joc)
        {
            List<int> iduri = new List<int>();
            iduri.Add(0);
            List<JocJucator> list = getListaJocJucatori(joc.id);

            foreach (var jj in list)
            {
                iduri.Add(jj.idjucator.Value);
            }

            return iduri;

        }

        //================== SA NU UITI SA IEI DIN FOLDER PARTEA CU MODIFICARE              RAND            ===========
        public int getRand(Joc joc)
        {
            return repojoc.GetModelById(joc.id).rand.Value;
        }

        public void AlegPoz1(Joc joc,Jucator jucator,string pozitie)
        {
            JocJucator jj = findJucatorInJoc(joc.id, jucator.id);
            int poz = Convert.ToInt32(pozitie);

            jj.poz1 = poz;
            repojocjucator.UpdateModel(jj);

        }

        public void AlegPoz2(Joc joc, Jucator jucator, string pozitie)
        {
            JocJucator jj = findJucatorInJoc(joc.id, jucator.id);
            int poz = Convert.ToInt32(pozitie);

            jj.poz2 = poz;
            repojocjucator.UpdateModel(jj);

        }

        public bool AlegPozAdversar(Joc joc,Jucator jucator,string pozitie)
        {


            JocJucator jucatoractual = findJucatorInJoc(joc.id, jucator.id);
            jucatoractual.pozaleasa = Convert.ToInt32(pozitie);
            repojocjucator.UpdateModel(jucatoractual);


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


            JocJucator jj = findAdversar(joc.id,jucator.id);
            int poz = Convert.ToInt32(pozitie);

            if (poz == jj.poz1)
            {
                jj.poz1 = 0;
                repojocjucator.UpdateModel(jj);


                return true;
            }

            if (poz == jj.poz2)
            {
                jj.poz2 = 0;
                repojocjucator.UpdateModel(jj);
                return true;
            }


            return false;


        }


        public int GataJoc(Joc joc)
        {
            List<JocJucator> list = getListaJocJucatori(joc.id);

            foreach (var jj in list)
                if (jj.poz1 == 0 && jj.poz2 == 0)
                {
                    Joc j = repojoc.GetModelById(joc.id);
                    j.castigator = findAdversar(joc.id, jj.idjucator.Value).idjucator.Value;
                    repojoc.UpdateModel(j);
                    return findAdversar(joc.id, jj.idjucator.Value).idjucator.Value;
                }

            return 0;

        }

        public int CeAlegere(Joc joc,Jucator jucator,string pozitie)
        {

            JocJucator jj = findJucatorInJoc(joc.id, jucator.id);

            if (jj.poz1 == -1)
                return 1;

            if (jj.poz2 == -1)
                    return 2;
            else
            {
                //AlegPozAdversar(joc, jucator, pozitie);
                return 3;
            }



        }

        public bool PozitieVadalida(Joc joc,Jucator jucator)
        {
            JocJucator jj = findJucatorInJoc(joc.id, jucator.id);

            if (jj.poz1 == jj.poz2 + 1 || jj.poz1 == jj.poz2 - 1)
                return true;

            if (jj.poz1 == jj.poz2 + 4 || jj.poz1 == jj.poz2 - 4)
                return true;

            jj.poz2 = -1;

            repojocjucator.UpdateModel(jj);

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


        public IList<IObserver> GetListaStandBy()
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
