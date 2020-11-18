using Microsoft.EntityFrameworkCore;
using ProyectoFinalAP2.DAL;
using ProyectoFinalAP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProyectoFinalAP2.BLL {
    public class UsuariosBLL {
        public static async Task<bool> Guardar(Usuarios usuario) {
            if (!await Existe(usuario.NombreUsuario))
                return await Insertar(usuario);
            else
                return await Modificar(usuario);
        }

        public static async Task<bool> Existe(string nombreUsuario) {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try {
                encontrado = contexto.Usuarios.Any(u => u.NombreUsuario == nombreUsuario);
            } catch (Exception) {

                throw;
            } finally {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static async Task<bool> Insertar(Usuarios usuario) {
            bool paso = false;
            Contexto contexto = new Contexto();

            try {
                usuario.Contraseña = Usuarios.Encriptar(usuario.Contraseña);
                contexto.Usuarios.Add(usuario);
                paso = await contexto.SaveChangesAsync() > 0;
            } catch (Exception) {
                throw;
            } finally {
                contexto.Dispose();
            }

            return paso;
        }

        public static async Task<bool> Modificar(Usuarios usuario) {
            bool paso = false;
            Contexto contexto = new Contexto();

            try {
                usuario.Contraseña = Usuarios.Encriptar(usuario.Contraseña);
                contexto.Entry(usuario).State = EntityState.Modified;
                paso = await contexto.SaveChangesAsync() > 0;
            } catch (Exception) {
                throw;
            } finally {
                contexto.Dispose();
            }

            return paso;
        }

        public static async Task<Usuarios> Buscar(string nombreUsuario) {
            Contexto contexto = new Contexto();
            Usuarios usuario;

            try {

                usuario = await contexto.Usuarios.FindAsync(nombreUsuario);
                if (usuario != null) {
                    usuario.Contraseña = Usuarios.DesEncriptar(usuario.Contraseña);

                }
            } catch (Exception) {
                throw;
            } finally {
                contexto.Dispose();
            }

            return usuario;
        }

        public static async Task<bool> Eliminar(int id) {
            bool paso = false;
            Contexto contexto = new Contexto();

            try {
                var usuario = contexto.Usuarios.Find(id);

                if (usuario != null) {
                    contexto.Usuarios.Remove(usuario);
                    paso = (await contexto.SaveChangesAsync() > 0);
                }
            } catch (Exception) {
                throw;
            } finally {
                contexto.Dispose();
            }

            return paso;
        }

        public static async Task<List<Usuarios>> GetList(Expression<Func<Usuarios , bool>> criterio) {
            List<Usuarios> listaUsuarios = new List<Usuarios>();
            Contexto contexto = new Contexto();

            try {
                listaUsuarios = await contexto.Usuarios.Where(criterio).ToListAsync();
            } catch (Exception) {
                throw;
            } finally {
                contexto.Dispose();
            }

            return listaUsuarios;
        }





    }
}
