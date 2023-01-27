﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Revista_digital.Modelo;
using Revista_digital.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revista_digital.Vista_Modelo
{
    class AutorVM : ObservableObject
    {
        public RelayCommand SelectImagenCommand { get; }

        public RelayCommand GuardarAutorCommand { get; }
        public RelayCommand EditarAutorCommand { get; }
        public RelayCommand EliminarAutorCommand { get; }

        private string nombreAutor;
        public string NombreAutor
        {
            get { return nombreAutor; }
            set { SetProperty(ref nombreAutor, value); }
        }

        private string imagenAutor;
        public string ImagenAutor
        {
            get { return imagenAutor; }
            set { SetProperty(ref imagenAutor, value); }
        }

        private string imagenRedSocial;
        public string ImagenRedSocial
        {
            get { return imagenRedSocial; }
            set { SetProperty(ref imagenRedSocial, value); }
        }

        private string nicknameAutor;
        public string NicknameAutor
        {
            get { return nicknameAutor; }
            set { SetProperty(ref nicknameAutor, value); }
        }

        private string nombreCrear;
        public string NombreCrear
        {
            get { return nombreCrear; }
            set { SetProperty(ref nombreCrear, value); }
        }

        private string nicknameCrear;
        public string NicknameCrear
        {
            get { return nicknameCrear; }
            set { SetProperty(ref nicknameCrear, value); }
        }

        private string imagenSeleccionadaPorUsuario;
        public string ImagenSeleccionadaPorUsuario
        {
            get { return imagenSeleccionadaPorUsuario; }
            set { SetProperty(ref imagenSeleccionadaPorUsuario, value); }
        }
        private string redSeleccionada;
        public string RedSeleccionada
        {
            get { return redSeleccionada; }
            set { SetProperty(ref redSeleccionada, value); }
        }
        private ObservableCollection<string> redes;
        public ObservableCollection<string> Redes
        {
            get { return redes; }
            set { SetProperty(ref redes, value); }
        }
        private ObservableCollection<Autor> listaAutores;
        public ObservableCollection<Autor> ListaAutores
        {
            get { return listaAutores; }
            set { SetProperty(ref listaAutores, value); }
        }
        private Autor autorSeleccionado;

        public Autor AutorSeleccionado
        {
            get { return autorSeleccionado; }
            set { SetProperty(ref autorSeleccionado, value); }
        }
        private GestionarAutorService gestionarAutorService;
        private DialogoService dialogoService;

        public AutorVM()
        {
            Redes = new ObservableCollection<string>();
            Redes.Add("Instagram");
            Redes.Add("Twitter");
            Redes.Add("Facebook");
            
            SelectImagenCommand = new RelayCommand(SeleccionarImagenAutor);
            GuardarAutorCommand = new RelayCommand(GuardarAutor);
            EditarAutorCommand = new RelayCommand(EditarAutor);
            EliminarAutorCommand = new RelayCommand(EliminarAutor);

            gestionarAutorService = new GestionarAutorService();
            dialogoService = new DialogoService();
        }

        private void EliminarAutor()
        {
            if (dialogoService.DialogoEliminar())
            {
                Autor autor = AutorSeleccionado;
                gestionarAutorService.EliminarAutor(autor);
            }
        }

        private void EditarAutor()
        {
            NombreCrear = AutorSeleccionado.Nombre;
            NicknameCrear = AutorSeleccionado.Nickname;
            ImagenAutor = AutorSeleccionado.Imagen;
            RedSeleccionada = AutorSeleccionado.RedSocial;

        }

        public void SeleccionarImagenAutor()
        {
            //Sera igual al resultado del servicio con la imagen seleccionada por el autor
            //ImagenSeleccionadaPorUsuario = 
        }
        public void GuardarAutor()
        {
            Autor autor = new Autor(NombreCrear, NicknameCrear, ImagenSeleccionadaPorUsuario, RedSeleccionada);
            gestionarAutorService.GuardarAutor(autor);
        }
    }
}
