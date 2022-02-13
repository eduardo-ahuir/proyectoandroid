using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CRUDFireBase.Helper;
using CRUDFireBase.Model;

namespace proyectoandroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Generar : ContentPage
    {
        int idpersonajeal = 0;
        public Generar()
        {
            InitializeComponent();


        }
        FirebaseHelper firebaseHelper = new FirebaseHelper();


        public async void GetPersonajeal()
        {
            var allIds = await firebaseHelper.GetAllPersonajes();

            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int idaleat = rnd.Next(0, allIds.Count());
            idpersonajeal = allIds[idaleat].Idpersonaje;



        }

        public async void GetPersonajeaclase()
        {
            var allIds = await firebaseHelper.GetAllPersonajes();
            Random rnd = new Random(Guid.NewGuid().GetHashCode());


            Boolean loop = true;



            for (int i = 0; i < allIds.Count; i++)
            {
                int idaleat = rnd.Next(0, allIds.Count());


                if (allIds[idaleat].Clase.Equals(claseselect.SelectedItem))
                {

                    idpersonajeal = allIds[idaleat].Idpersonaje;

                }


            }





        }
        public async void GetPersonajearaza()
        {
            var allIds = await firebaseHelper.GetAllPersonajes();
            Random rnd = new Random(Guid.NewGuid().GetHashCode());


            Boolean loop = true;


            for (int i = 0; i < allIds.Count(); i++)
            {
                int idaleat = rnd.Next(0, allIds.Count());


                if (allIds[idaleat].Raza.Equals(razaselect.SelectedItem))
                {

                    idpersonajeal = allIds[idaleat].Idpersonaje;
                    loop = false;
                }

            }





        }

        public async void GetPersonajearazayclase()
        {
            var allIds = await firebaseHelper.GetAllPersonajes();
            Random rnd = new Random(Guid.NewGuid().GetHashCode());


            Boolean loop = true;


            for (int i = 0; i < allIds.Count; i++)
            {
                int idaleat = rnd.Next(0, allIds.Count());


                if (allIds[idaleat].Raza.Equals(razaselect.SelectedItem))
                {
                    if (allIds[idaleat].Clase.Equals(claseselect.SelectedItem))
                    {

                        idpersonajeal = allIds[idaleat].Idpersonaje;
                        loop = false;

                    }

                }

            }





        }

        private void limpiar()
        {
            Nombre.Text = String.Empty;
            Clase.Text = String.Empty;
            Raza.Text = String.Empty;
            Url.Source = String.Empty;
            Rasgo.Text = "Rasgo:";
            Ideal.Text = "Ideal:";
            Vinculo.Text = "Vinculo:";
            Defecto.Text = "Defecto:";
            Objeto.Text = "Objeto:";
            Moral.Text = "Moral:";

        }


        private async void GeneraRandom(object sender, EventArgs e)
        {


            if (claseselect.SelectedItem != null && razaselect.SelectedItem != null)
            {
                GetPersonajearazayclase();

            }
            else
            {
                if (claseselect.SelectedItem != null)
                {
                    GetPersonajeaclase();
                    razaselect.SelectedItem = null;
                }
                else
                {
                    if (razaselect.SelectedItem != null)
                    {
                        GetPersonajearaza();
                        claseselect.SelectedItem = null;
                    }
                    else { GetPersonajeal(); }
                }
            }





            var personaje = await firebaseHelper.GetPersonaje(idpersonajeal);
            if (personaje != null)
            {
                limpiar();
                Nombre.Text = personaje.Nombre.ToString();
                Clase.Text = "Clase:" + personaje.Clase;
                Raza.Text = "Raza:" + personaje.Raza;
                Url.Source = personaje.URL;
                Rasgo.Text = Rasgo.Text + personaje.Rasgo;
                Ideal.Text = Ideal.Text + personaje.Ideal;
                Vinculo.Text = Vinculo.Text + personaje.Vinculo;
                Defecto.Text = Defecto.Text + personaje.Defecto;
                Objeto.Text = Objeto.Text + personaje.Objeto;
                Moral.Text = Moral.Text + personaje.Alineamiento;
                fuen.Text = personaje.Fuerza.ToString();
                desn.Text = personaje.Destreza.ToString();
                conn.Text = personaje.Constitución.ToString();
                intn.Text = personaje.Inteligencia.ToString();
                sabn.Text = personaje.Sabiduria.ToString();
                carn.Text = personaje.Carisma.ToString();
                modificadoresfue();
                modificadoresdes();
                modificadorescon();
                modificadoresint();
                modificadoressab();
                modificadorescar();
                claseselect.SelectedIndex = -1;
                razaselect.SelectedIndex = -1;

                await DisplayAlert("Éxito", "Personaje generado con exito", "Aceptar");

            }
            else
            {
                await DisplayAlert("Alerta", "Error en la generacion del personaje vuelve a intentarlo y si el error persiste contacta con el Administrador", "Aceptar");
            }

        }


        private void modificadoresfue()
        {

            switch (Convert.ToInt32(fuen.Text))
            {

                case 3:
                    fuem.Text = "-4";
                    break;
                case 4:
                    fuem.Text = "-3";
                    break;
                case 5:
                    fuem.Text = "-3";
                    break;
                case 6:
                    fuem.Text = "-2";
                    break;
                case 7:
                    fuem.Text = "-2";
                    break;
                case 8:
                    fuem.Text = "-1";
                    break;
                case 9:
                    fuem.Text = "-1";
                    break;
                case 10:
                    fuem.Text = "0";
                    break;
                case 11:
                    fuem.Text = "0";
                    break;
                case 12:
                    fuem.Text = "+1";
                    break;
                case 13:
                    fuem.Text = "+1";
                    break;
                case 14:
                    fuem.Text = "+2";
                    break;
                case 15:
                    fuem.Text = "+2";
                    break;
                case 16:
                    fuem.Text = "+3";
                    break;
                case 17:
                    fuem.Text = "+3";
                    break;
                case 18:
                    fuem.Text = "+4";
                    break;


            }}
        private void modificadoresdes()
        {

            switch (Convert.ToInt32(desn.Text))
            {

                case 3:
                    desm.Text = "-4";
                    break;
                case 4:
                    desm.Text = "-3";
                    break;
                case 5:
                    desm.Text = "-3";
                    break;
                case 6:
                    desm.Text = "-2";
                    break;
                case 7:
                    desm.Text = "-2";
                    break;
                case 8:
                    desm.Text = "-1";
                    break;
                case 9:
                    desm.Text = "-1";
                    break;
                case 10:
                    desm.Text = "0";
                    break;
                case 11:
                    desm.Text = "0";
                    break;
                case 12:
                    desm.Text = "+1";
                    break;
                case 13:
                    desm.Text = "+1";
                    break;
                case 14:
                    desm.Text = "+2";
                    break;
                case 15:
                    desm.Text = "+2";
                    break;
                case 16:
                    desm.Text = "+3";
                    break;
                case 17:
                    desm.Text = "+3";
                    break;
                case 18:
                    desm.Text = "+4";
                    break;


            }}


        private void modificadorescon()
        {

            switch (Convert.ToInt32(conn.Text))
            {

                case 3:
                    conm.Text = "-4";
                    break;
                case 4:
                    conm.Text = "-3";
                    break;
                case 5:
                    conm.Text = "-3";
                    break;
                case 6:
                    conm.Text = "-2";
                    break;
                case 7:
                    conm.Text = "-2";
                    break;
                case 8:
                    conm.Text = "-1";
                    break;
                case 9:
                    conm.Text = "-1";
                    break;
                case 10:
                    conm.Text = "0";
                    break;
                case 11:
                    conm.Text = "0";
                    break;
                case 12:
                    conm.Text = "+1";
                    break;
                case 13:
                    conm.Text = "+1";
                    break;
                case 14:
                    conm.Text = "+2";
                    break;
                case 15:
                    conm.Text = "+2";
                    break;
                case 16:
                    conm.Text = "+3";
                    break;
                case 17:
                    conm.Text = "+3";
                    break;
                case 18:
                    conm.Text = "+4";
                    break;


            }
        }
        private void modificadoresint()
        {

            switch (Convert.ToInt32(intn.Text))
            {

                case 3:
                    intm.Text = "-4";
                    break;
                case 4:
                    intm.Text = "-3";
                    break;
                case 5:
                    intm.Text = "-3";
                    break;
                case 6:
                    intm.Text = "-2";
                    break;
                case 7:
                    intm.Text = "-2";
                    break;
                case 8:
                    intm.Text = "-1";
                    break;
                case 9:
                    intm.Text = "-1";
                    break;
                case 10:
                    intm.Text = "0";
                    break;
                case 11:
                    intm.Text = "0";
                    break;
                case 12:
                    intm.Text = "+1";
                    break;
                case 13:
                    intm.Text = "+1";
                    break;
                case 14:
                    intm.Text = "+2";
                    break;
                case 15:
                    intm.Text = "+2";
                    break;
                case 16:
                    intm.Text = "+3";
                    break;
                case 17:
                    intm.Text = "+3";
                    break;
                case 18:
                    intm.Text = "+4";
                    break;


            }
        }
        private void modificadoressab()
        {

            switch (Convert.ToInt32(sabn.Text))
            {

                case 3:
                    sabm.Text = "-4";
                    break;
                case 4:
                    sabm.Text = "-3";
                    break;
                case 5:
                    sabm.Text = "-3";
                    break;
                case 6:
                    sabm.Text = "-2";
                    break;
                case 7:
                    sabm.Text = "-2";
                    break;
                case 8:
                    sabm.Text = "-1";
                    break;
                case 9:
                    sabm.Text = "-1";
                    break;
                case 10:
                    sabm.Text = "0";
                    break;
                case 11:
                    sabm.Text = "0";
                    break;
                case 12:
                    sabm.Text = "+1";
                    break;
                case 13:
                    sabm.Text = "+1";
                    break;
                case 14:
                    sabm.Text = "+2";
                    break;
                case 15:
                    sabm.Text = "+2";
                    break;
                case 16:
                    sabm.Text = "+3";
                    break;
                case 17:
                    sabm.Text = "+3";
                    break;
                case 18:
                    sabm.Text = "+4";
                    break;


            }
        }

        private void modificadorescar()
        {

            switch (Convert.ToInt32(carn.Text))
            {

                case 3:
                    carm.Text = "-4";
                    break;
                case 4:
                    carm.Text = "-3";
                    break;
                case 5:
                    carm.Text = "-3";
                    break;
                case 6:
                    carm.Text = "-2";
                    break;
                case 7:
                    carm.Text = "-2";
                    break;
                case 8:
                    carm.Text = "-1";
                    break;
                case 9:
                    carm.Text = "-1";
                    break;
                case 10:
                    carm.Text = "0";
                    break;
                case 11:
                    carm.Text = "0";
                    break;
                case 12:
                    carm.Text = "+1";
                    break;
                case 13:
                    carm.Text = "+1";
                    break;
                case 14:
                    carm.Text = "+2";
                    break;
                case 15:
                    carm.Text = "+2";
                    break;
                case 16:
                    carm.Text = "+3";
                    break;
                case 17:
                    carm.Text = "+3";
                    break;
                case 18:
                    carm.Text = "+4";
                    break;


            }
        }

    }
}

