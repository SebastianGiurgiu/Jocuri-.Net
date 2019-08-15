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
        Repository<Jucator> repojucatori;
        Repository<Joc> repojocs;
        Repository<JucatorJoc> repojucatorijoc;

        List<string> mylist = new List<string>(new string[] { "nuc", "par", "lemn", "ceva", "altceva" });



        public MyServer(Repository<User> repouser, Repository<Jucator> repojucatori, Repository<Joc> repojocs, Repository<JucatorJoc> repojucatorijoc)
        {
            this.repouser = repouser;
            this.repojucatori = repojucatori;
            this.repojocs = repojocs;
            this.repojucatorijoc = repojucatorijoc;
        }

        public bool findAftertUsernameAndPassword(string username, string password)
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


        public Jucator cautJucator(string username)
        {
            foreach (var juc in repojucatori.GetModel())
            {
            //    Console.WriteLine(juc.username);
                if (juc.username.Equals(username))
                {
                    return juc;
                }
            }
            return null;
        }

        public string GenerareCuvant()
        {
            Random random = new Random();
            int num = random.Next(3);
            return mylist[num];
        }

        public int creareJoc()
        {
            Joc joc = new Joc()
            {
                castigator = -1
            };
            repojocs.InsertModel(joc);
            repojocs.Save();

            return joc.id;
        }

        public void creareJucatorJoc(List<int> iduri, int idJoc)
        {
            foreach (var idjucator in iduri)
            {
                JucatorJoc jucatorJoc = new JucatorJoc()
                {
                    idJucator = idjucator,
                    idJoc = idJoc,
                    numarcuvinte = 0,
                    punctaj = 0
                };

                repojucatorijoc.InsertModel(jucatorJoc);
                repojucatorijoc.Save();

            }
        }

      public List<IObserver> getJucatori()
        {
            return (List<IObserver>) observers;
        }


        public bool SfarsitJoc(int idJoc)
        {
            List<JucatorJoc> list = new List<JucatorJoc>();
            foreach (var jucatorjoc in repojucatorijoc.GetModel())
            {
                if (jucatorjoc.idJoc == idJoc)
                {
                    list.Add(jucatorjoc);
                }
            }

            int nrcuv = 3;
            foreach (var juc in list)
            {
                if (juc.numarcuvinte == nrcuv)
                    return true;
            }

            return false;


        }


        public bool TreciLaUrmatorulCuvant(int idJoc)
        {

            List<JucatorJoc> list = new List<JucatorJoc>();
            List<JucatorJoc> listjucator = (List<JucatorJoc>) repojucatorijoc.GetModel();

            foreach (var jucatorjoc in listjucator)
            {
                if (jucatorjoc.idJoc == idJoc)
                {
                    list.Add(jucatorjoc);
                }
            }

           // Console.WriteLine(list.Count);

            int nrcuv = list[0].numarcuvinte.Value;

            foreach (var juc in list)
            {
                if (juc.numarcuvinte != nrcuv)
                    return false;
            }

            return true;

        }


        public void selectareCuvantJucator(int idJucator, int idJoc, string cuv)
        {
            foreach (var jucatorjoc in repojucatorijoc.GetModel())
            {
                if (jucatorjoc.idJucator == idJucator && jucatorjoc.idJoc == idJoc)
                {
                    jucatorjoc.numarcuvinte += 1;
                    if (jucatorjoc.numarcuvinte == 1)
                    {
                        jucatorjoc.cuvant1 = cuv;
                    }
                    if (jucatorjoc.numarcuvinte == 2)
                    {
                        jucatorjoc.cuvant2 = cuv;
                    }
                    if (jucatorjoc.numarcuvinte == 3)
                    {
                        jucatorjoc.cuvant3 = cuv;
                    }

                    repojucatorijoc.UpdateModel(jucatorjoc);
                    repojucatorijoc.Save();
                    //   break;
                }
            }

        }












        private IList<IObserver> standby = new List<IObserver>();

        private IList<IObserver> observers = new List<IObserver>();

    
       public void startJoc()
        {
            foreach(IObserver ob in standby)
            {
                observers.Add(ob);
            }
            standby.Clear();
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
