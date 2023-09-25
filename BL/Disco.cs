using DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Disco
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JAlarconPruebaTecnica2Entities context = new DL.JAlarconPruebaTecnica2Entities())
                {

                    var tablaDisco = context.DiscoGetAll();

                    if (tablaDisco != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var disco in tablaDisco)
                        {
                            ML.Disco disco1 = new ML.Disco();
                            disco1.IdDisco = disco.IdDisco;
                            disco1.Titulo = disco.Titulo;
                            disco1.Artista = disco.Artista;
                            disco1.GeneroMusical = disco.GeneroMusical;
                            disco1.Duracion = disco.Duracion;
                            disco1.Año = disco.Año;
                            disco1.Distribuidora = disco.Distribuidora;
                            disco1.Ventas = disco.Ventas;
                            disco1.Disponibilidad = disco.Disponibilidad;
                            result.Objects.Add(disco1);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }


                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result Add(ML.Disco disco)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL.JAlarconPruebaTecnica2Entities context = new DL.JAlarconPruebaTecnica2Entities())
                {


                    int rowAffected = context.DiscoAdd(disco.Titulo, disco.Artista, disco.GeneroMusical, disco.Duracion, disco.Año, disco.Distribuidora, disco.Ventas, disco.Disponibilidad);
                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;
        }

        public static ML.Result Delete(int IdDisco)
        {


            ML.Result result = new ML.Result();
            try
            {
                using (DL.JAlarconPruebaTecnica2Entities contex = new DL.JAlarconPruebaTecnica2Entities())
                {
                    int rowAffected = contex.DiscoDelete(IdDisco);
                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
            }
            return result;
        }


        public static ML.Result Update(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JAlarconPruebaTecnica2Entities context = new DL.JAlarconPruebaTecnica2Entities())
                {

                    int rowAffected = context.DiscoUpdate(disco.IdDisco, disco.Titulo, disco.Artista, disco.GeneroMusical, disco.Duracion, disco.Año, disco.Distribuidora, disco.Ventas, disco.Disponibilidad);
                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;

        }

        public static ML.Result GetByI(int IdDisco)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JAlarconPruebaTecnica2Entities context = new DL.JAlarconPruebaTecnica2Entities())
                {

                    var tablaDiscos = context.DiscoGetById(IdDisco).FirstOrDefault();


                    //                    result.Objects = new List<object>();    No se ocupa por que solo nos regresara 1 dato


                    if (tablaDiscos != null)
                    {


                        ML.Disco disco = new ML.Disco();



                        disco.IdDisco = tablaDiscos.IdDisco;
                        disco.Titulo = tablaDiscos.Titulo;
                        disco.Artista = tablaDiscos.Artista;
                        disco.GeneroMusical = tablaDiscos.GeneroMusical;
                            disco.Duracion = tablaDiscos.Duracion;
                        disco.Año = tablaDiscos.Año;
                        disco.Distribuidora = tablaDiscos.Distribuidora;
                        disco.Ventas = tablaDiscos.Ventas;
                        disco.Disponibilidad = tablaDiscos.Disponibilidad;

                        result.Object = disco;


                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La tabla usuario no contiene registros";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;

        }


    }
}
