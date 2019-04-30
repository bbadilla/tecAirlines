using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tecAirlinesServices.Models;

namespace tecAirlinesServices.Logic
{
    public class UserLogic
    {
        /// <summary>
        /// Lista de usuarios
        /// </summary>
        /// <returns></returns>
        public List<object> GetUsers()
        {
            List<Object> dataList = new List<object>();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var userList = entities.Usuarios.ToList();
                    int n = userList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < userList.Count; ++i)
                        {
                            UserData data = new UserData();
                            data.Nombre = userList.ElementAt(i).Nombre;
                            data.Apellido1 = userList.ElementAt(i).Apellido1;
                            data.Apellido2 = userList.ElementAt(i).Apellido2;
                            data.Telefono = userList.ElementAt(i).Telefono;
                            data.Carne = userList.ElementAt(i).Carne;
                            data.Correo = userList.ElementAt(i).Correo;
                            data.Contraseña = userList.ElementAt(i).Contraseña;
                            dataList.Add(data);
                        }
                        return dataList;
                    }
                }
                catch
                {

                    dataList = null;
                    return dataList;

                }

            }
        }


        /// <summary>
        /// Get de un usuario especifico
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public UserData GetUser(string correo)
        {
            UserData user = new UserData();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    if (!this.ExistUser(correo))
                    {
                        user = null;
                        return user;
                    }
                    var userx = entities.Usuarios.Find(correo);
                    user.Nombre = userx.Nombre;
                    user.Apellido1 = userx.Apellido1;
                    user.Apellido2 = userx.Apellido2;
                    user.Telefono = userx.Telefono;
                    user.Carne = userx.Carne;
                    user.Universidad = userx.Universidad;
                    user.Correo = userx.Correo;
                    user.Contraseña = userx.Contraseña;
                    return user;

                }
                catch (Exception)
                {
                    user = null;
                    return user;
                }
            }
        }

        /// <summary>
        /// //Verifica si un usuario existe
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public bool ExistUser(string correo)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                var i = entities.Usuarios.Find(correo);
                if (i == null) return false;
                else return true;
            }
        }

        /// <summary>
        /// Agrega un nuevo usuario
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddUser(UserData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                //Usuario newUser = new Usuario();
                //newUser.Nombre = data.Nombre;
                //newUser.Apellido1 = data.Apellido1;
                //newUser.Apellido2 = data.Apellido2;
                //newUser.Telefono = data.Telefono;
                //newUser.Carne = data.Carne;
                //newUser.Correo = data.Correo;
                //newUser.Contraseña = data.Contraseña;
                try
                {
                    //entities.Usuarios.Add(newUser);
                    //entities.SaveChanges();
                   
                    int entity = entities.Insertar_Usuario(data.Nombre, data.Apellido1, data.Apellido2, data.Telefono, data.Carne, data.Universidad, data.Correo, data.Contraseña);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public bool DeleteUser(string correo)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var ms = entities.Usuarios.Find(correo);
                    entities.Usuarios.Remove(ms);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Actualizar un usuario
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateUser(UserData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var user = entities.Usuarios.Find(data.Correo);
                    user.Nombre = data.Nombre;
                    user.Apellido1 = data.Apellido1;
                    user.Apellido2 = data.Apellido2;
                    user.Telefono = data.Telefono;
                    user.Carne = data.Carne;
                    user.Correo = data.Correo;
                    user.Universidad = data.Universidad;
                    user.Contraseña = data.Contraseña;
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }


    }
}