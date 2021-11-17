using System;

using System.Data;


namespace Evaluacion4ITS
{
    public class DatosLista
    {


        public DataTable DT { get; set; } = new DataTable();
        public int UltimoId { get; set; } = 0;

        public DatosLista()
        {
            DT.TableName = "Lista de Productos";
            DT.Columns.Add("Id");
            DT.Columns.Add("Nombre");
            DT.Columns.Add("Precio");
            DT.Columns.Add("Cantidad");

            LeerDT_DeArchivo();
        }

        public void LeerDT_DeArchivo()
        {
            if (System.IO.File.Exists("Lista.xml"))
            {
        
                DT.ReadXml("Lista.xml");
                UltimoId = 0;
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    if (Convert.ToInt32(DT.Rows[i]["Id"]) > UltimoId)
                    {
                        UltimoId = Convert.ToInt32(DT.Rows[i]["Id"]);
                    }
                }
            }
        }

        public bool UpdateDatos(Datos datos)
        {
            bool respuesta = datos.Validar();

            if (respuesta)
            {
                if (datos.Id == 0)
                {
                    UltimoId = UltimoId + 1;
                    datos.Id = UltimoId;

                    DT.Rows.Add();
                    int NumeroRegistroNuevo = DT.Rows.Count - 1;

                    DT.Rows[NumeroRegistroNuevo]["Id"] = datos.Id.ToString();
                    DT.Rows[NumeroRegistroNuevo]["Nombre"] = datos.Nombre;
                    DT.Rows[NumeroRegistroNuevo]["Precio"] = datos.Precio.ToString();
                    DT.Rows[NumeroRegistroNuevo]["Cantidad"] = datos.Cantidad.ToString();

                    DT.WriteXml("Lista.xml");
                }
                else
                {
                    for (int fila = 0; fila < DT.Rows.Count; fila++)
                    {
                        if (Convert.ToInt32(DT.Rows[fila]["Id"]) == datos.Id)
                        {
                            DT.Rows[fila]["Nombre"] = datos.Nombre;
                            DT.Rows[fila]["Precio"] = datos.Precio.ToString();
                            DT.Rows[fila]["Cantidad"] = datos.Cantidad.ToString();
                            DT.WriteXml("Lista.xml");
                            break;
                        }
                    }
                }
            }
            return respuesta;
        }

      

        public bool Borrar(Datos datos)
        {
            bool resp = false;
            DT.Rows.Clear();
            DT.WriteXml("Lista.xml");
            resp = true;
            return resp;
        }

     

        

    }

}




