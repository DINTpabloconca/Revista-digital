﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revista_digital.Modelo
{
    class Articulo : ObservableObject
    {
        private string autor;

        public string Autor
        {
            get { return autor; }
            set { SetProperty(ref autor, value); }
        }


        private string titulo;

        public string Titulo
        {
            get { return titulo; }
            set { SetProperty(ref titulo, value); }
        }

        private string cuerpo;

        public string Cuerpo
        {
            get { return cuerpo; }
            set { SetProperty(ref cuerpo, value); }
        }

        private string imagen;

        public string Imagen
        {
            get { return imagen; }
            set { SetProperty(ref imagen, value); }
        }

        private string nickname;

        public string Nickname
        {
            get { return nickname; }
            set { SetProperty(ref nickname, value); }
        }

        public Articulo(string autor, string titulo, string cuerpo, string imagen, string nickname)
        {
            Autor = autor;
            Titulo = titulo;
            Cuerpo = cuerpo;
            Imagen = imagen;
            Nickname = nickname;
        }

        public Articulo(string autor, string titulo, string cuerpo, string nickname)
        {
            Autor = autor;
            Titulo = titulo;
            Cuerpo = cuerpo;
            Nickname = nickname;
        }

        public Articulo()
        {

        }

    }
}