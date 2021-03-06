﻿using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public void Delete(Usuario entity)
        {
            usuarioRepository.Delete(entity);
        }

        public Usuario FindByApodoOrEmail(string search)
        {
            //Apodo no puede contener '@', Email debe contener '@' para ser válido
            Usuario usuario = new Usuario{ Apodo = search, Email = search };
            return usuarioRepository.FindByApodoOrEmail(usuario);
        }

        public Usuario FindById(Usuario entity)
        {
            return usuarioRepository.FindById(entity);
        }

        public List<Usuario> ListAll()
        {
            return usuarioRepository.ListAll();
        }

        public void Save(Usuario entity)
        {
            usuarioRepository.Save(entity);
        }

        public void Update(Usuario entity)
        {
            usuarioRepository.Update(entity);
        }
    }
}