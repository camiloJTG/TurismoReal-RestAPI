using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TurismoReal;
using TR.negocio.Clases.Listado;
using TR.negocio.Clases.Productos;
using TR.negocio.Seguridad;

namespace TR.negocio.Procedimientos.Productos
{
    public class Pro_departamento
    {
        private readonly Entities db = new Entities();
        private readonly Numero numero = new Numero();

        public List<TR_listadoDepartamento> ListarDepartamento()
        {
            var listado = db.DEPARTAMENTO.Select(x => new TR_listadoDepartamento
                {
                    DEPARTAMENTO_ID = x.DEPARTAMENTO_ID,
                    DEPARTAMENTO_VALOR = x.VALOR,
                    DEPARTAMENTO_NOMBRE = x.NOMBRE,
                    DEPARTAMENTO_DIRECCION = x.DIRECCION,
                    DEPARTAMENTO_SUPERFICIE = x.SUPERFICIE,
                    DEPARTAMENTO_CONDICIONES_USO = x.CONDICIONES_USO,
                    DEPARTAMENTO_FECHA_CREACION = x.FECHA_CREACION,
                    COMUNA_ID = x.COMUNA_ID,
                    COMUNA_NOMBRE = x.COMUNA.NOMBRE_COMUNA,
                    ESTADO_ID = x.ESTADO_ID,
                    ESTADO_ENTIDAD = x.ESTADO.ENTIDAD,
                    ESTADO_CODIGO = x.ESTADO.CODIGO,
                    ESTADO_DESCRIPCION = x.ESTADO.DESCRIPCION,
                    //SERVICIO_ID = x.servicio.SERVICIO_ID,
                    //SERVICIO_NOMBRE = x.servicio.SERVICIO.NOMBRE,
                    //SERVICIO_DESCRIPCION = x.servicio.SERVICIO.DESCRIPCION,
                    //INVENTARIO_ID = x.inventario.INVENTARIO_ID,
                    //INVENTARIO_DESCRIPCION = x.inventario.DESCRIPCION,
                    //INVENTARIO_NOMBRE = x.inventario.NOMBRE,
                    //ENTORNO_ID = x.entorno.ENTORNO_ID,
                    //ENTORNO_NOMBRE = x.entorno.NOMBRE,
                    //ENTORNO_IMG = x.entorno.IMG,
                });
            return listado.ToList();
        }

        public List<TR_listadoDepartamento> BuscarDepartamento(decimal id)
        {
            var listado = db.DEPARTAMENTO.Where(x => x.DEPARTAMENTO_ID == id).Select(x => new TR_listadoDepartamento
                {
                    DEPARTAMENTO_ID = x.DEPARTAMENTO_ID,
                    DEPARTAMENTO_VALOR = x.VALOR,
                    DEPARTAMENTO_NOMBRE = x.NOMBRE,
                    DEPARTAMENTO_DIRECCION = x.DIRECCION,
                    DEPARTAMENTO_SUPERFICIE = x.SUPERFICIE,
                    DEPARTAMENTO_CONDICIONES_USO = x.CONDICIONES_USO,
                    DEPARTAMENTO_FECHA_CREACION = x.FECHA_CREACION,
                    COMUNA_ID = x.COMUNA_ID,
                    COMUNA_NOMBRE = x.COMUNA.NOMBRE_COMUNA,
                    ESTADO_ID = x.ESTADO_ID,
                    ESTADO_ENTIDAD = x.ESTADO.ENTIDAD,
                    ESTADO_CODIGO = x.ESTADO.CODIGO,
                    ESTADO_DESCRIPCION = x.ESTADO.DESCRIPCION,
                    //SERVICIO_ID = x.servicio.SERVICIO_ID,
                    //SERVICIO_NOMBRE = x.servicio.SERVICIO.NOMBRE,
                    //SERVICIO_DESCRIPCION = x.servicio.SERVICIO.DESCRIPCION,
                    //INVENTARIO_ID = x.inventario.INVENTARIO_ID,
                    //INVENTARIO_DESCRIPCION = x.inventario.DESCRIPCION,
                    //INVENTARIO_NOMBRE = x.inventario.NOMBRE,
                    //ENTORNO_ID = x.entorno.ENTORNO_ID,
                    //ENTORNO_NOMBRE = x.entorno.NOMBRE,
                    //ENTORNO_IMG = x.entorno.IMG
                });
            return listado.ToList();
        }

        public void AgregarDepartamento(TR_departamento departamento)
        {
            var data = db.DEPARTAMENTO.Create();

            data.DEPARTAMENTO_ID = numero.numeroAleatorio();
            data.VALOR = departamento.VALOR;
            data.NOMBRE = departamento.NOMBRE;
            data.DIRECCION = departamento.DIRECCION;
            data.COMUNA_ID = departamento.COMUNA_ID;
            data.SUPERFICIE = departamento.SUPERFICIE;
            data.CONDICIONES_USO = departamento.CONDICIONES_USO;
            data.FECHA_CREACION = departamento.FECHA_CREACION;
            data.ESTADO_ID = departamento.ESTADO_ID;

            db.DEPARTAMENTO.Add(data);
            db.SaveChanges();
        }

        public void EliminarDepartamento(decimal id)
        {
            var resultado = db.DEPARTAMENTO.Find(id);
            var depto_servicio = db.DEPARTAMENTO_SERVICIO.FirstOrDefault(x=>x.DEPARTAMENTO_ID == id);
            var depto_entorno = db.DEPARTAMENTO.FirstOrDefault();
            
            db.DEPARTAMENTO.Remove(resultado);
            db.SaveChanges();
        }

        public void ActualizarDepartamento(decimal id, TR_departamento departamento)
        {
            var resultado = db.DEPARTAMENTO.Find(id);
            db.Entry(resultado).CurrentValues.SetValues(departamento);
            db.Entry(resultado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool ExisteDepartamento(decimal id)
        {
            var resultado = db.DEPARTAMENTO.FirstOrDefault(x=>x.DEPARTAMENTO_ID == id);
            if (resultado != null)
            {
                return true; 
            }
            return false;
        }
    }
}
