using DataAccess.DAO;
using DTO;
using DTO.Laboratorios;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper.Laboratorios
{
    public class LaboratorioMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos CRUD
        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_CrearLaboratorio"
            };

            var laboratorio = (Laboratorio)entidadDTO;
            operation.AddIntegerParam("id_proveedor", laboratorio.id_proveedor);
            operation.AddVarcharParam("nombre", laboratorio.nombre);
            operation.AddVarcharParam("nombre_comercial", laboratorio.nombre_comercial);
            operation.AddVarcharParam("cedula_juridica", laboratorio.cedula_juridica);
            operation.AddVarcharParam("razon_social", laboratorio.razon_social);
            operation.AddVarcharParam("tel_contacto", laboratorio.tel_contacto);
            operation.AddVarcharParam("correo_electronico", laboratorio.correo_electronico);
            operation.AddVarcharParam("provincia", laboratorio.provincia);
            operation.AddVarcharParam("canton", laboratorio.canton);
            operation.AddVarcharParam("distrito", laboratorio.distrito);
            operation.AddVarcharParam("direccion", laboratorio.direccion);
            operation.AddVarcharParam("web_site", laboratorio.web_site);
            operation.AddVarcharParam("url_facebook", laboratorio.url_facebook);
            operation.AddVarcharParam("url_linkedin", laboratorio.url_linkedin);
            operation.AddVarcharParam("url_instagram", laboratorio.url_instagram);
            operation.AddVarcharParam("url_twitter", laboratorio.url_twitter);
            operation.AddVarcharParam("ruta_fotos1", laboratorio.ruta_fotos1);
            operation.AddVarcharParam("ruta_fotos2", laboratorio.ruta_fotos2);
            operation.AddVarcharParam("ruta_fotos3", laboratorio.ruta_fotos3);
            operation.AddVarcharParam("ruta_fotos4", laboratorio.ruta_fotos4);
            operation.AddVarcharParam("ruta_fotos5", laboratorio.ruta_fotos5);

            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ListarLaboratorios"
            };

            return operation;
        }

        public SqlOperation GetDeleteStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetAllRetrieveByIdStatement(int idProv)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ListarLaboratoriosId"
            };
            operation.AddIntegerParam("id_proveedor", idProv);
            return operation;
        }
        public SqlOperation GetRepresentante(int idLab)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ObtenerRepresentanteLab"
            };
            operation.AddIntegerParam("idLab", idLab);
            return operation;
        }
        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(int idLab, int idProv)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_EliminarLaboratorio"

            };
            operation.AddIntegerParam("idLab", idLab);
            operation.AddIntegerParam("idProv", idProv);
            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int idLab, int idProv)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ObtenerLaboratorio"

            };
            operation.AddIntegerParam("idLab", idLab);
            operation.AddIntegerParam("idProv", idProv);
            return operation;
        }

        public SqlOperation GetUpdateStatement(int idLab, int idProv, EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_EditarLaboratorio"
            };

            var laboratorio = (Laboratorio)entidadDTO;
            operation.AddIntegerParam("idLab", idLab);
            operation.AddIntegerParam("idProv", idProv);
            operation.AddVarcharParam("nombre", laboratorio.nombre);
            operation.AddVarcharParam("nombre_comercial", laboratorio.nombre_comercial);
            operation.AddVarcharParam("cedula_juridica", laboratorio.cedula_juridica);
            operation.AddVarcharParam("razon_social", laboratorio.razon_social);
            operation.AddVarcharParam("tel_contacto", laboratorio.tel_contacto);
            operation.AddVarcharParam("correo_electronico", laboratorio.correo_electronico);
            operation.AddVarcharParam("provincia", laboratorio.provincia);
            operation.AddVarcharParam("canton", laboratorio.canton);
            operation.AddVarcharParam("distrito", laboratorio.distrito);
            operation.AddVarcharParam("direccion", laboratorio.direccion);
            operation.AddVarcharParam("web_site", laboratorio.web_site);
            operation.AddVarcharParam("url_facebook", laboratorio.url_facebook);
            operation.AddVarcharParam("url_linkedin", laboratorio.url_linkedin);
            operation.AddVarcharParam("url_instagram", laboratorio.url_instagram);
            operation.AddVarcharParam("url_twitter", laboratorio.url_twitter);

            return operation;
        }
        #endregion

        #region Object Mappers
        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            var laboratorio = new Laboratorio()
            {
                id = int.Parse(row["id"].ToString()),
                nombre = row["nombre"].ToString(),
                nombre_comercial = row["nombre_comercial"].ToString(),
                cedula_juridica = row["cedula_juridica"].ToString(),
                razon_social = row["razon_social"].ToString(),
                tel_contacto = row["tel_contacto"].ToString(),
                correo_electronico = row["correo_electronico"].ToString(),
                provincia = row["provincia"].ToString(),
                canton = row["canton"].ToString(),
                distrito = row["distrito"].ToString(),
                direccion = row["direccion"].ToString(),
                web_site = row["web_site"].ToString(),
                url_facebook = row["url_facebook"].ToString(),
                url_linkedin = row["url_linkedin"].ToString(),
                url_instagram = row["url_instagram"].ToString(),
                url_twitter = row["url_twitter"].ToString(),
                fecha_registro = row["fecha_registro"].ToString(),
                estado = row["estado"].ToString(),
                ruta_fotos1 = row["ruta_fotos1"].ToString(),
            };

            return laboratorio;
        }

        public List<EntidadBase> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<EntidadBase>();

            foreach (var row in lstRows)
            {
                var laboratorio = BuildObject(row);
                lstResults.Add(laboratorio);
            }
            return lstResults;
        }

        public EntidadBase BuildObjectID(Dictionary<string, object> row)
        {
            var laboratorio = new Laboratorio()
            {
                nombre = row["nombre"].ToString(),
                nombre_comercial = row["nombre_comercial"].ToString(),
                cedula_juridica = row["cedula_juridica"].ToString(),
                razon_social = row["razon_social"].ToString(),
                tel_contacto = row["tel_contacto"].ToString(),
                correo_electronico = row["correo_electronico"].ToString(),
                provincia = row["provincia"].ToString(),
                canton = row["canton"].ToString(),
                distrito = row["distrito"].ToString(),
                direccion = row["direccion"].ToString(),
                web_site = row["web_site"].ToString(),
                url_facebook = row["url_facebook"].ToString(),
                url_linkedin = row["url_linkedin"].ToString(),
                url_instagram = row["url_instagram"].ToString(),
                url_twitter = row["url_twitter"].ToString(),
            };


            return laboratorio;
        }

        public List<EntidadBase> BuildObjectsID(List<Dictionary<string, object>> listRows)
        {
            var lstResults = new List<EntidadBase>();

            foreach (var row in listRows)
            {
                var laboratorio = BuildObjectID(row);
                lstResults.Add(laboratorio);
            }

            return lstResults;
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
