using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace AutoTradeDoo.Models
{
    public class Automobil
    {
        public Automobil()
        {

        }

        public Automobil(string proizvodjac, string model, int godiste, int kilometraza, string gorivo, string emisioniStandard, string brojVrata, string tip, int velicinaFelgi, string transmisija, string brojStepeniPrijenosa)
        {
            this.proizvodjac = proizvodjac;
            this.model = model;
            this.godiste = godiste;
            this.kilometraza = kilometraza;
            this.gorivo = gorivo;
            this.emisioniStandard = emisioniStandard;
            this.brojVrata = brojVrata;
            this.tip = tip;
            this.velicinaFelgi = velicinaFelgi;
            this.transmisija = transmisija;
            this.brojStepeniPrijenosa = brojStepeniPrijenosa;
        }
        
        private string proizvodjac;
        private string model;
        private int godiste;
        private int kilometraza;
        private string gorivo;
        private string emisioniStandard;
        private string brojVrata;
        private string tip;
        private int velicinaFelgi;
        private string transmisija;
        private string brojStepeniPrijenosa;

        public int Id { get; set; }

         
        public byte[] Image  { get; set; }

        public string Proizvodjac
        {
            get
            {
                return proizvodjac;
            }

            set
            {
                proizvodjac = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public int Godiste
        {
            get
            {
                return godiste;
            }

            set
            {
                godiste = value;
            }
        }

        public int Kilometraza
        {
            get
            {
                return kilometraza;
            }

            set
            {
                kilometraza = value;
            }
        }

        public string Gorivo
        {
            get
            {
                return gorivo;
            }

            set
            {
                gorivo = value;
            }
        }

        public string EmisioniStandard
        {
            get
            {
                return emisioniStandard;
            }

            set
            {
                emisioniStandard = value;
            }
        }

        public string BrojVrata
        {
            get
            {
                return brojVrata;
            }

            set
            {
                brojVrata = value;
            }
        }

        public string Tip
        {
            get
            {
                return tip;
            }

            set
            {
                tip = value;
            }
        }

        public int VelicinaFelgi
        {
            get
            {
                return velicinaFelgi;
            }

            set
            {
                velicinaFelgi = value;
            }
        }

        public string Transmisija
        {
            get
            {
                return transmisija;
            }

            set
            {
                transmisija = value;
            }
        }

        public string BrojStepeniPrijenosa
        {
            get
            {
                return brojStepeniPrijenosa;
            }

            set
            {
                brojStepeniPrijenosa = value;
            }
        }

        //Image slika;
        /* public Image Slika
         {
             get
             {
                 return slika;
             }
             set
             {
                 slika = value;
             }
         }*/
        
    }
}