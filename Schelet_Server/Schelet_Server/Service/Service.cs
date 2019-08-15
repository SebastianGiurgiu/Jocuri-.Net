using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schelet_Server.Repository;


namespace Schelet_Server.Service
{
   public class Service
    {

        Repository<User> repouser;
        Repository<Juriu> repojuriu;
        Repository<Participant> repoparticipant;
        Repository<PunctajPartcipant> repopunctaj;
                
        public Service(Repository<User> repouser,Repository<Juriu> repojuriu,Repository<Participant> repoparticipant,Repository<PunctajPartcipant> repopunctaj) 
        {
            this.repouser = repouser;
            this.repojuriu = repojuriu;
            this.repoparticipant = repoparticipant;
            this.repopunctaj = repopunctaj;
        }

        public bool findAftertUsernameAndPassword(string username,string password)
        {
            try
            {
                User user = repouser.GetModelById(username);
                if (user.password.Equals(password))
                    return true;
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
          
        }

        public IEnumerable<Participant> GetParticipants()
        {
            return repoparticipant.GetModel();
        }


        public Juriu GetJuriuAfterUsername(string username)
        {
            List<Juriu> list =(List<Juriu>) repojuriu.GetModel();

            foreach(var juriu in list)
            {
                if (juriu.username.Equals(username))
                {
                    return juriu;
                }
            }

            return null;

        }


        public void AdaugaRezultat(int idParticipant,int scor,string aspect)
        {

           // Participant participant = repoparticipant.GetModelById(idParticipant);

            PunctajPartcipant punctaj = repopunctaj.GetModelById(idParticipant);
       

            if (aspect.Equals("lungime"))
            {
                // participant.lungime += scor;
                punctaj.lungime = scor;
            }

            if (aspect.Equals("aterizare"))
            {
                //  participant.aterizare += scor;
                punctaj.aterizare = scor;
            }

            if (aspect.Equals("stil"))
            {
                //  participant.stil += scor;
                punctaj.stil = scor;
            }

            repopunctaj.UpdateModel(punctaj);
            repopunctaj.Save();
          

        }


        public void JurizatComplet(int idParticipant)
        {

            PunctajPartcipant punctaj = repopunctaj.GetModelById(idParticipant);
            if(punctaj.lungime!=0 && punctaj.stil!=0 && punctaj.aterizare != 0)
            {
                Participant participant = repoparticipant.GetModelById(idParticipant);
                if (!participant.status.Equals("finished"))
                {

                    participant.lungime += punctaj.lungime;
                    participant.aterizare += punctaj.aterizare;
                    participant.stil += punctaj.stil;

                    // mai schimbi si statusul 

                    repoparticipant.UpdateModel(participant);
                    repoparticipant.Save();


                    punctaj.stil = 0;
                    punctaj.aterizare = 0;
                    punctaj.lungime = 0;
                    repopunctaj.UpdateModel(punctaj);
                    repopunctaj.Save();
                }
            }


        }


    }
}
