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
            var listado = db.DEPARTAMENTO.Join(db.DEPARTAMENTO_SERVICIO, depto => depto.DEPARTAMENTO_ID, serv => serv.DEPARTAMENTO_ID, (departamento, servicio) => new { departamento, servicio }).
                Join(db.INVENTARIO, deptoIn => deptoIn.departamento.DEPARTAMENTO_ID, inventario => inventario.INVENTARIO_ID, (deptoInventario, inventario) => new { deptoInventario.departamento, deptoInventario.servicio, inventario }).
                Join(db.ENTORNO, deptoEntor=>deptoEntor.departamento.DEPARTAMENTO_ID, entorno=>entorno.ENTORNO_ID, (deptoEntorno,entorno)=> new {deptoEntorno.departamento, deptoEntorno.servicio, deptoEntorno.inventario, entorno }).
                Select(x => new TR_listadoDepartamento
                {
                    DEPARTAMENTO_ID = x.departamento.DEPARTAMENTO_ID,
                    DEPARTAMENTO_VALOR = x.departamento.VALOR,
                    DEPARTAMENTO_NOMBRE = x.departamento.NOMBRE,
                    DEPARTAMENTO_DIRECCION = x.departamento.DIRECCION,
                    DEPARTAMENTO_SUPERFICIE = x.departamento.SUPERFICIE,
                    DEPARTAMENTO_CONDICIONES_USO = x.departamento.CONDICIONES_USO,
                    DEPARTAMENTO_FECHA_CREACION = x.departamento.FECHA_CREACION,
                    COMUNA_ID = x.departamento.COMUNA_ID,
                    COMUNA_NOMBRE = x.departamento.COMUNA.NOMBRE_COMUNA,
                    ESTADO_ID = x.departamento.ESTADO_ID,
                    ESTADO_ENTIDAD = x.departamento.ESTADO.ENTIDAD,
                    ESTADO_CODIGO = x.departamento.ESTADO.CODIGO,
                    ESTADO_DESCRIPCION = x.departamento.ESTADO.DESCRIPCION,
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
            var listado = db.DEPARTAMENTO.Where(x => x.DEPARTAMENTO_ID == id).Join(db.DEPARTAMENTO_SERVICIO, depto => depto.DEPARTAMENTO_ID, serv => serv.DEPARTAMENTO_ID, (departamento, servicio) => new { departamento, servicio }).
                Join(db.INVENTARIO, deptoIn => deptoIn.departamento.DEPARTAMENTO_ID, inventario => inventario.INVENTARIO_ID, (deptoInventario, inventario) => new { deptoInventario.departamento, deptoInventario.servicio, inventario }).
                Join(db.ENTORNO, deptoEntor => deptoEntor.departamento.DEPARTAMENTO_ID, entorno => entorno.ENTORNO_ID, (deptoEntorno, entorno) => new { deptoEntorno.departamento, deptoEntorno.servicio, deptoEntorno.inventario, entorno }).
                Select(x => new TR_listadoDepartamento
                {
                    DEPARTAMENTO_ID = x.departamento.DEPARTAMENTO_ID,
                    DEPARTAMENTO_VALOR = x.departamento.VALOR,
                    DEPARTAMENTO_NOMBRE = x.departamento.NOMBRE,
                    DEPARTAMENTO_DIRECCION = x.departamento.DIRECCION,
                    DEPARTAMENTO_SUPERFICIE = x.departamento.SUPERFICIE,
                    DEPARTAMENTO_CONDICIONES_USO = x.departamento.CONDICIONES_USO,
                    DEPARTAMENTO_FECHA_CREACION = x.departamento.FECHA_CREACION,
                    COMUNA_ID = x.departamento.COMUNA_ID,
                    COMUNA_NOMBRE = x.departamento.COMUNA.NOMBRE_COMUNA,
                    ESTADO_ID = x.departamento.ESTADO_ID,
                    ESTADO_ENTIDAD = x.departamento.ESTADO.ENTIDAD,
                    ESTADO_CODIGO = x.departamento.ESTADO.CODIGO,
                    ESTADO_DESCRIPCION = x.departamento.ESTADO.DESCRIPCION,
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
