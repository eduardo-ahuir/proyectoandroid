using CRUDFireBase.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace CRUDFireBase.Helper

{

    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://generapjs-5a-default-rtdb.europe-west1.firebasedatabase.app/");
        
        public async Task<List<Personaje>> GetAllPersonajes()
        {

            return (await firebase
              .Child("generapjs-5a-default-rtdb")
              .OnceAsync<Personaje>()).Select(item => new Personaje
              {
                  Idpersonaje = item.Object.Idpersonaje,
                  Nombre = item.Object.Nombre,
                  Clase = item.Object.Clase,
                  Raza = item.Object.Raza,
                  URL = item.Object.URL,
                  Rasgo = item.Object.Rasgo,
                  Ideal = item.Object.Ideal,
                  Vinculo = item.Object.Vinculo,
                  Defecto = item.Object.Defecto,
                  Objeto = item.Object.Objeto,
                  Alineamiento= item.Object.Alineamiento,
                  Fuerza = item.Object.Fuerza,
                  Destreza = item.Object.Destreza,
                  Constitución=item.Object.Constitución,
                  Inteligencia=item.Object.Inteligencia,
                  Sabiduria=item.Object.Sabiduria,
                  Carisma=item.Object.Carisma,

              }).ToList();
        
        }
        public async Task<List<Personaje>> GetAllusurios()
        {

            return (await firebase
              .Child("generapjs-5a-default-rtdb")
              .OnceAsync<Personaje>()).Select(item => new Personaje
              {
                 usuario=item.Object.usuario,
                 contraseña=item.Object.contraseña,

              }).ToList();

        }


        public async Task AddPersonaje(int idpersonaje,string nombre,string clase,string raza,string url,string rasgo,string ideal,string vinculo,string defecto,string objeto,string alineamiento,int fuerza, int destreza, int contitucion,int inteligencia,int sabiduria,int carisma)
        {

            await firebase
              .Child("generapjs-5a-default-rtdb")
              .PostAsync(new Personaje() { Idpersonaje=idpersonaje,Nombre=nombre,Clase=clase,Raza=raza,URL=url,Rasgo=rasgo,Ideal=ideal,Vinculo=vinculo,Defecto=defecto,Objeto=objeto,Alineamiento=alineamiento,Fuerza=fuerza,Destreza=destreza,Constitución=contitucion,Inteligencia=inteligencia,Sabiduria=sabiduria,Carisma=carisma });
        }

        public async Task<Personaje> GetPersonaje(int idpersonaje)
        {
            var allPersonajes = await GetAllPersonajes();
            await firebase
              .Child("generapjs-5a-default-rtdb")
              .OnceAsync<Personaje>();
            return allPersonajes.Where(a => a.Idpersonaje == idpersonaje).FirstOrDefault();
        }



        public async Task UpdatePersonaje(int idpersonaje, string nombre, string clase, string raza, string url, string rasgo, string ideal, string vinculo, string defecto, string objeto, string alineamiento)
        {
            var toUpdatePersonaje = (await firebase
              .Child("generapjs-5a-default-rtdb")
              .OnceAsync<Personaje>()).Where(a => a.Object.Idpersonaje == idpersonaje).FirstOrDefault();

            await firebase
              .Child("generapjs-5a-default-rtdb")
              .Child(toUpdatePersonaje.Key)
              .PutAsync(new Personaje() { Idpersonaje = idpersonaje, Nombre = nombre, Clase = clase, Raza = raza, URL = url, Rasgo = rasgo, Ideal = ideal, Vinculo = vinculo, Defecto = defecto, Objeto = objeto,Alineamiento=alineamiento});
        }

        public async Task DeletePersonaje(int idpersonaje)
        {
            var toDeletePersonaje = (await firebase
              .Child("generapjs-5a-default-rtdb")
              .OnceAsync<Personaje>()).Where(a => a.Object.Idpersonaje == idpersonaje).FirstOrDefault();
            await firebase.Child("generapjs-5a-default-rtdb").Child(toDeletePersonaje.Key).DeleteAsync();

        }

        public async Task Addusuario(string usuario,string contraseña  )
        {

            await firebase
              .Child("generapjs-5a-default-rtdb")
              .PostAsync(new Personaje() { usuario=usuario,contraseña=contraseña });
        }



    }
}
