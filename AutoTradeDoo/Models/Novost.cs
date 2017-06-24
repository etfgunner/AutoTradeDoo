using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoTradeDoo.Models
{
    public class Novost
    {
        public int Id { get; set; }

        public byte[] Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        public string Sadrzaj
        {
            get
            {
                return sadrzaj;
            }

            set
            {
                sadrzaj = value;
            }
        }

        private byte[] image;
        private string sadrzaj;
        public Novost()
        {

        }
        public Novost(byte[] image, string sadrzaj)
        {
            this.image = image;
            this.sadrzaj = sadrzaj;
        }
    }
}