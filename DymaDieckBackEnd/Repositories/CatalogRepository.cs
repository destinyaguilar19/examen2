using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DymaDieckBackend.exceptions;
using DymaDieckBackend.Entity;

namespace DymaDieckBackend.Repositories
{
    internal class CatalogRepository
    {
        private IDbConnection db = null;
        private string sqlConnectionString = "";
        public CatalogRepository(string ConnectionString)
        {
            if (string.IsNullOrEmpty(ConnectionString))
                throw new ArgumentNullException("ConnectionString is required");
            this.sqlConnectionString = ConnectionString;
        }
        
        #region Empresa
        public List<vwEmpresa> TraerEmpresas(int? Activo)
        {
            var resp = new List<vwEmpresa>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwEmpresa>("Select * From vwEmpresa with(nolock) Where Activo = IsNull(@Activo, Activo) order by NombreEmpresa", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public EmpresaCatalogo GuardarEmpresa(EmpresaCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Empresa Datos requeridos");

            if (datos.NPK_Empresa == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Empresa = connection.Insert<EmpresaCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Empresa = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<EmpresaCatalogo>(datos.NPK_Empresa, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<EmpresaCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Empresa = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public EmpresaCatalogo GuardarEmpresaActivo(long NPK_Empresa, int Activo, int NFK_User)
        {
            EmpresaCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<EmpresaCatalogo>(NPK_Empresa, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<EmpresaCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region TipoEmpleado
        public List<vwTipoEmpleado> TraerTipoEmpleados(int? Activo)
        {
            var resp = new List<vwTipoEmpleado>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwTipoEmpleado>("Select * From vwTipoEmpleado with(nolock) Where Activo = IsNull(@Activo, Activo) order by TipoEmpleado", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public TipoEmpleadoCatalogo GuardarTipoEmpleado(TipoEmpleadoCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("TipoEmpleado Datos requeridos");

            if (datos.NPK_TipoEmpleado == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_TipoEmpleado = connection.Insert<TipoEmpleadoCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoEmpleado = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<TipoEmpleadoCatalogo>(datos.NPK_TipoEmpleado, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<TipoEmpleadoCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoEmpleado = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public TipoEmpleadoCatalogo GuardarTipoEmpleadoActivo(long NPK_TipoEmpleado, int Activo, int NFK_User)
        {
            TipoEmpleadoCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<TipoEmpleadoCatalogo>(NPK_TipoEmpleado, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<TipoEmpleadoCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Empleado
        public List<vwEmpleado> TraerEmpleados(int? Activo)
        {
            var resp = new List<vwEmpleado>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwEmpleado>("Select * From vwEmpleado with(nolock) Where Activo = IsNull(@Activo, Activo) order by Nombres, ApellidoPaterno, ApellidoMaterno", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public EmpleadoCatalogo GuardarEmpleado(EmpleadoCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Empleado Datos requeridos");

            if (datos.NPK_Empleado == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Empleado = connection.Insert<EmpleadoCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Empleado = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<EmpleadoCatalogo>(datos.NPK_Empleado, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<EmpleadoCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Empleado = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public EmpleadoCatalogo GuardarEmpleadoActivo(long NPK_Empleado, int Activo, int NFK_User)
        {
            EmpleadoCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<EmpleadoCatalogo>(NPK_Empleado, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<EmpleadoCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Instalador
        public List<vwInstalador> TraerInstaladors(int? Activo)
        {
            var resp = new List<vwInstalador>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwInstalador>("Select * From vwInstalador with(nolock) Where Activo = IsNull(@Activo, Activo) order by Nombres, ApellidoPaterno, ApellidoMaterno", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public InstaladorCatalogo GuardarInstalador(InstaladorCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Instalador Datos requeridos");

            if (datos.NPK_Instalador == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Instalador = connection.Insert<InstaladorCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Instalador = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<InstaladorCatalogo>(datos.NPK_Instalador, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<InstaladorCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Instalador = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public InstaladorCatalogo GuardarInstaladorActivo(long NPK_Instalador, int Activo, int NFK_User)
        {
            InstaladorCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<InstaladorCatalogo>(NPK_Instalador, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<InstaladorCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region RegistroIMSS
        public List<vwRegistroIMSS> TraerRegistroIMSSs(int? Activo)
        {
            var resp = new List<vwRegistroIMSS>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwRegistroIMSS>("Select * From vwRegistroIMSS with(nolock) Where Activo = IsNull(@Activo, Activo) order by Fecha_Inicio", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public RegistroIMSSCatalogo GuardarRegistroIMSS(RegistroIMSSCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("RegistroIMSS Datos requeridos");

            if (datos.NPK_Registro_IMSS == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Registro_IMSS = connection.Insert<RegistroIMSSCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Registro_IMSS = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<RegistroIMSSCatalogo>(datos.NPK_Registro_IMSS, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<RegistroIMSSCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Registro_IMSS = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public RegistroIMSSCatalogo GuardarRegistroIMSSActivo(long NPK_RegistroIMSS, int Activo, int NFK_User)
        {
            RegistroIMSSCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<RegistroIMSSCatalogo>(NPK_RegistroIMSS, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<RegistroIMSSCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Material
        public List<vwMaterial> TraerMaterials(int? Activo)
        {
            var resp = new List<vwMaterial>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwMaterial>("Select * From vwMaterial with(nolock) Where Activo = IsNull(@Activo, Activo) order by Material", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public MaterialCatalogo GuardarMaterial(MaterialCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Material Datos requeridos");

            if (datos.NPK_Material == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Material = connection.Insert<MaterialCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Material = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<MaterialCatalogo>(datos.NPK_Material, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<MaterialCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Material = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public MaterialCatalogo GuardarMaterialActivo(long NPK_Material, int Activo, int NFK_User)
        {
            MaterialCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<MaterialCatalogo>(NPK_Material, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<MaterialCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region UnidadMedida
        public List<vwUnidadMedida> TraerUnidadMedidas(int? Activo)
        {
            var resp = new List<vwUnidadMedida>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwUnidadMedida>("Select * From vwUnidadMedida with(nolock) Where Activo = IsNull(@Activo, Activo) order by UnidadMedida", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public UnidadMedidaCatalogo GuardarUnidadMedida(UnidadMedidaCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("UnidadMedida Datos requeridos");

            if (datos.NPK_UnidadMedida == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_UnidadMedida = connection.Insert<UnidadMedidaCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_UnidadMedida = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<UnidadMedidaCatalogo>(datos.NPK_UnidadMedida, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<UnidadMedidaCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_UnidadMedida = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public UnidadMedidaCatalogo GuardarUnidadMedidaActivo(long NPK_UnidadMedida, int Activo, int NFK_User)
        {
            UnidadMedidaCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<UnidadMedidaCatalogo>(NPK_UnidadMedida, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<UnidadMedidaCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }



        #endregion
        #region Categoria
        public List<vwCategorias> TraerCategoriass(int? Activo)
        {
            var resp = new List<vwCategorias>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwCategorias>("Select * From vwCategoria with(nolock) Where Activo = IsNull(@Activo, Activo) order by Categoria", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public CategoriasCatalogo GuardarCategorias(CategoriasCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Categorias Datos requeridos");

            if (datos.NPK_Categoria == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Categoria = connection.Insert<CategoriasCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Categoria = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<CategoriasCatalogo>(datos.NPK_Categoria, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<CategoriasCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Categoria = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public CategoriasCatalogo GuardarCategoriasActivo(long NPK_Categorias, int Activo, int NFK_User)
        {
            CategoriasCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<CategoriasCatalogo>(NPK_Categorias, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<CategoriasCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }
        #endregion
        #region Espesor
        public List<vwEspesor> TraerEspesors(int? Activo)
        {
            var resp = new List<vwEspesor>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwEspesor>("Select * From vwEspesor with(nolock) Where Activo = IsNull(@Activo, Activo) order by Espesor", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public EspesorCatalogo GuardarEspesor(EspesorCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Espesor Datos requeridos");

            if (datos.NPK_Espesor == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Espesor = connection.Insert<EspesorCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Espesor = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<EspesorCatalogo>(datos.NPK_Espesor, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<EspesorCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Espesor = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public EspesorCatalogo GuardarEspesorActivo(long NPK_Espesor, int Activo, int NFK_User)
        {
            EspesorCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<EspesorCatalogo>(NPK_Espesor, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<EspesorCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Formapago
        public List<vwFormapago> TraerFormapagos(int? Activo)
        {
            var resp = new List<vwFormapago>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwFormapago>("Select * From vwFormapago with(nolock) Where Activo = IsNull(@Activo, Activo) order by Formapago", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public FormapagoCatalogo GuardarFormapago(FormapagoCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Formapago Datos requeridos");

            if (datos.NPK_FormaPago == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_FormaPago = connection.Insert<FormapagoCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_FormaPago = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<FormapagoCatalogo>(datos.NPK_FormaPago, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<FormapagoCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_FormaPago = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public FormapagoCatalogo GuardarFormapagoActivo(long NPK_FormaPago, int Activo, int NFK_User)
        {
            FormapagoCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<FormapagoCatalogo>(NPK_FormaPago, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<FormapagoCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Cliente
        public List<vwCliente> TraerClientes(int? Activo)
        {
            var resp = new List<vwCliente>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwCliente>("Select * From vwCliente with(nolock) Where Activo = IsNull(@Activo, Activo) order by NombreCliente", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public ClienteCatalogo GuardarCliente(ClienteCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Cliente Datos requeridos");

            if (datos.NPK_Cliente == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Cliente = connection.Insert<ClienteCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Cliente = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<ClienteCatalogo>(datos.NPK_Cliente, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<ClienteCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Cliente = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public ClienteCatalogo GuardarClienteActivo(long NPK_Cliente, int Activo, int NFK_User)
        {
            ClienteCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<ClienteCatalogo>(NPK_Cliente, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<ClienteCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Fleteroterrestre
        public List<vwFleteroterrestre> TraerFleteroterrestres(int? Activo)
        {
            var resp = new List<vwFleteroterrestre>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwFleteroterrestre>("Select * From vwFleteroterrestre with(nolock) Where Activo = IsNull(@Activo, Activo) order by Fleteroterrestre", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public FleteroterrestreCatalogo GuardarFleteroterrestre(FleteroterrestreCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Fleteroterrestre Datos requeridos");

            if (datos.NPK_FleteroTerrestre == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_FleteroTerrestre = connection.Insert<FleteroterrestreCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_FleteroTerrestre = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<FleteroterrestreCatalogo>(datos.NPK_FleteroTerrestre, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<FleteroterrestreCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_FleteroTerrestre = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public FleteroterrestreCatalogo GuardarFleteroterrestreActivo(long NPK_Fleteroterrestre, int Activo, int NFK_User)
        {
            FleteroterrestreCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<FleteroterrestreCatalogo>(NPK_Fleteroterrestre, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<FleteroterrestreCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Forwarder
        public List<vwForwarder> TraerForwarders(int? Activo)
        {
            var resp = new List<vwForwarder>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwForwarder>("Select * From vwForwarder with(nolock) Where Activo = IsNull(@Activo, Activo) order by Forwarder" +
                        "", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public ForwarderCatalogo GuardarForwarder(ForwarderCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Forwarder Datos requeridos");

            if (datos.NPK_Forwarder == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Forwarder = connection.Insert<ForwarderCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Forwarder = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<ForwarderCatalogo>(datos.NPK_Forwarder, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<ForwarderCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Forwarder = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public ForwarderCatalogo GuardarForwarderActivo(long NPK_Forwarder, int Activo, int NFK_User)
        {
            ForwarderCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<ForwarderCatalogo>(NPK_Forwarder, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<ForwarderCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Herramienta
        public List<vwHerramienta> TraerHerramientas(int? Activo)
        {
            var resp = new List<vwHerramienta>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwHerramienta>("Select * From vwHerramienta with(nolock) Where Activo = IsNull(@Activo, Activo) order by Herramienta", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public HerramientaCatalogo GuardarHerramienta(HerramientaCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Herramienta Datos requeridos");

            if (datos.NPK_Herramienta == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Herramienta = connection.Insert<HerramientaCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Herramienta = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<HerramientaCatalogo>(datos.NPK_Herramienta, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<HerramientaCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Herramienta = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public HerramientaCatalogo GuardarHerramientaActivo(long NPK_Herramienta, int Activo, int NFK_User)
        {
            HerramientaCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<HerramientaCatalogo>(NPK_Herramienta, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<HerramientaCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Iva
        public List<vwIva> TraerIvas(int? Activo)
        {
            var resp = new List<vwIva>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwIva>("Select * From vwIva with(nolock) Where Activo = IsNull(@Activo, Activo) order by Iva", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public IvaCatalogo GuardarIva(IvaCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Iva Datos requeridos");

            if (datos.NPK_Iva == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Iva = connection.Insert<IvaCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Iva = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<IvaCatalogo>(datos.NPK_Iva, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<IvaCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Iva = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public IvaCatalogo GuardarIvaActivo(long NPK_Iva, int Activo, int NFK_User)
        {
            IvaCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<IvaCatalogo>(NPK_Iva, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<IvaCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Medida
        public List<vwMedida> TraerMedidas(int? Activo)
        {
            var resp = new List<vwMedida>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwMedida>("Select * From vwMedida with(nolock) Where Activo = IsNull(@Activo, Activo) order by Medida", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public MedidaCatalogo GuardarMedida(MedidaCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Medida Datos requeridos");

            if (datos.NPK_Medida == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Medida = connection.Insert<MedidaCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Medida = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<MedidaCatalogo>(datos.NPK_Medida, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<MedidaCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Medida = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public MedidaCatalogo GuardarMedidaActivo(long NPK_Medida, int Activo, int NFK_User)
        {
            MedidaCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<MedidaCatalogo>(NPK_Medida, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<MedidaCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Moneda
        public List<vwMoneda> TraerMonedas(int? Activo)
        {
            var resp = new List<vwMoneda>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwMoneda>("Select * From vwMoneda with(nolock) Where Activo = IsNull(@Activo, Activo) order by Moneda", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public MonedaCatalogo GuardarMoneda(MonedaCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Moneda Datos requeridos");

            if (datos.NPK_Moneda == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Moneda = connection.Insert<MonedaCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Moneda = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<MonedaCatalogo>(datos.NPK_Moneda, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<MonedaCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Moneda = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public MonedaCatalogo GuardarMonedaActivo(long NPK_Moneda, int Activo, int NFK_User)
        {
            MonedaCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<MonedaCatalogo>(NPK_Moneda, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<MonedaCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Motivodevolucion
        public List<vwMotivodevolucion> TraerMotivodevolucions(int? Activo)
        {
            var resp = new List<vwMotivodevolucion>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwMotivodevolucion>("Select * From vwMotivodevolucion with(nolock) Where Activo = IsNull(@Activo, Activo) order by MotivoDevolucion", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public MotivodevolucionCatalogo GuardarMotivodevolucion(MotivodevolucionCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Motivodevolucion Datos requeridos");

            if (datos.NPK_MotivoDevolucion == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_MotivoDevolucion = connection.Insert<MotivodevolucionCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_MotivoDevolucion = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<MotivodevolucionCatalogo>(datos.NPK_MotivoDevolucion, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<MotivodevolucionCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_MotivoDevolucion = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public MotivodevolucionCatalogo GuardarMotivodevolucionActivo(long NPK_Motivodevolucion, int Activo, int NFK_User)
        {
            MotivodevolucionCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<MotivodevolucionCatalogo>(NPK_Motivodevolucion, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<MotivodevolucionCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Naviera
        public List<vwNaviera> TraerNavieras(int? Activo)
        {
            var resp = new List<vwNaviera>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwNaviera>("Select * From vwNaviera with(nolock) Where Activo = IsNull(@Activo, Activo) order by Naviera", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public NavieraCatalogo GuardarNaviera(NavieraCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Naviera Datos requeridos");

            if (datos.NPK_Naviera == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Naviera = connection.Insert<NavieraCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Naviera = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<NavieraCatalogo>(datos.NPK_Naviera, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<NavieraCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Naviera = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public NavieraCatalogo GuardarNavieraActivo(long NPK_Naviera, int Activo, int NFK_User)
        {
            NavieraCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<NavieraCatalogo>(NPK_Naviera, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<NavieraCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Paisorigen
        public List<vwPaisOrigen> TraerPaisOrigens(int? Activo)
        {
            var resp = new List<vwPaisOrigen>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwPaisOrigen>("Select * From vwPaisOrigen with(nolock) Where Activo = IsNull(@Activo, Activo) order by PaisOrigen", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public PaisOrigenCatalogo GuardarPaisOrigen(PaisOrigenCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("PaisOrigen Datos requeridos");

            if (datos.NPK_PaisOrigen == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_PaisOrigen = connection.Insert<PaisOrigenCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_PaisOrigen = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<PaisOrigenCatalogo>(datos.NPK_PaisOrigen, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<PaisOrigenCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_PaisOrigen = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public PaisOrigenCatalogo GuardarPaisOrigenActivo(long NPK_PaisOrigen, int Activo, int NFK_User)
        {
            PaisOrigenCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<PaisOrigenCatalogo>(NPK_PaisOrigen, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<PaisOrigenCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Producto
        public List<vwProducto> TraerProductos(int? Activo)
        {
            var resp = new List<vwProducto>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwProducto>("Select * From vwProducto with(nolock) Where Activo = IsNull(@Activo, Activo) order by NombreMaterialDieck", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public ProductoCatalogo GuardarProducto(ProductoCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Producto Datos requeridos");

            if (datos.NPK_Producto == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Producto = connection.Insert<ProductoCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Producto = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<ProductoCatalogo>(datos.NPK_Producto, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<ProductoCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Producto = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public ProductoCatalogo GuardarProductoActivo(long NPK_Producto, int Activo, int NFK_User)
        {
            ProductoCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<ProductoCatalogo>(NPK_Producto, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<ProductoCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Proveedor
        public List<vwProveedor> TraerProveedors(int? Activo)
        {
            var resp = new List<vwProveedor>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwProveedor>("Select * From vwProveedor with(nolock) Where Activo = IsNull(@Activo, Activo) order by NombreProveedor", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public ProveedorCatalogo GuardarProveedor(ProveedorCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Proveedor Datos requeridos");

            if (datos.NPK_Proveedor == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Proveedor = connection.Insert<ProveedorCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Proveedor = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<ProveedorCatalogo>(datos.NPK_Proveedor, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<ProveedorCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Proveedor = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public ProveedorCatalogo GuardarProveedorActivo(long NPK_Proveedor, int Activo, int NFK_User)
        {
            ProveedorCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<ProveedorCatalogo>(NPK_Proveedor, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<ProveedorCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Servicio
        public List<vwServicio> TraerServicios(int? Activo)
        {
            var resp = new List<vwServicio>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwServicio>("Select * From vwServicio with(nolock) Where Activo = IsNull(@Activo, Activo) order by Servicio", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public ServicioCatalogo GuardarServicio(ServicioCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Servicio Datos requeridos");

            if (datos.NPK_Servicio == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Servicio = connection.Insert<ServicioCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Servicio = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<ServicioCatalogo>(datos.NPK_Servicio, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<ServicioCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Servicio = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public ServicioCatalogo GuardarServicioActivo(long NPK_Servicio, int Activo, int NFK_User)
        {
            ServicioCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<ServicioCatalogo>(NPK_Servicio, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<ServicioCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Subcategoria
        public List<vwSubCategoria> TraerSubcategoriass(int? Activo)
        {
            var resp = new List<vwSubCategoria>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwSubCategoria>("Select * From vwSubcategoria with(nolock) Where Activo = IsNull(@Activo, Activo) order by SubCategoria", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public SubCategoriasCatalogo GuardarSubcategorias(SubCategoriasCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Subcategorias Datos requeridos");

            if (datos.NPK_SubCategoria == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_SubCategoria = connection.Insert<SubCategoriasCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_SubCategoria = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<SubCategoriasCatalogo>(datos.NPK_SubCategoria, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<SubCategoriasCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_SubCategoria = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public SubCategoriasCatalogo GuardarSubcategoriasActivo(long NPK_Subcategoria, int Activo, int NFK_User)
        {
            SubCategoriasCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<SubCategoriasCatalogo>(NPK_Subcategoria, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<SubCategoriasCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region TipoAcabado
        public List<vwTipoAcabado> TraerTipoAcabados(int? Activo)
        {
            var resp = new List<vwTipoAcabado>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwTipoAcabado>("Select * From vwTipoAcabado with(nolock) Where Activo = IsNull(@Activo, Activo) order by TipoAcabado", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public TipoAcabadoCatalogo GuardarTipoAcabado(TipoAcabadoCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("TipoAcabado Datos requeridos");

            if (datos.NPK_TipoAcabado == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_TipoAcabado = connection.Insert<TipoAcabadoCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoAcabado = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<TipoAcabadoCatalogo>(datos.NPK_TipoAcabado, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<TipoAcabadoCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoAcabado = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public TipoAcabadoCatalogo GuardarTipoAcabadoActivo(long NPK_TipoAcabado, int Activo, int NFK_User)
        {
            TipoAcabadoCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<TipoAcabadoCatalogo>(NPK_TipoAcabado, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<TipoAcabadoCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }


        #endregion
        #region TipoComentario
        public List<vwTipoComentario> TraerTipoComentarios(int? Activo)
        {
            var resp = new List<vwTipoComentario>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwTipoComentario>("Select * From vwTipoComentario with(nolock) Where Activo = IsNull(@Activo, Activo) order by TipoComentario", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public TipoComentarioCatalogo GuardarTipoComentario(TipoComentarioCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("TipoComentario Datos requeridos");

            if (datos.NPK_TipoComentario == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_TipoComentario = connection.Insert<TipoComentarioCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoComentario = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<TipoComentarioCatalogo>(datos.NPK_TipoComentario, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<TipoComentarioCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoComentario = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public TipoComentarioCatalogo GuardarTipoComentarioActivo(long NPK_TipoComentario, int Activo, int NFK_User)
        {
            TipoComentarioCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<TipoComentarioCatalogo>(NPK_TipoComentario, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<TipoComentarioCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region TipoDevolucion
        public List<vwTipoDevolucion> TraerTipoDevolucions(int? Activo)
        {
            var resp = new List<vwTipoDevolucion>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwTipoDevolucion>("Select * From vwTipoDevolucion with(nolock) Where Activo = IsNull(@Activo, Activo) order by TipoDevolucion", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public TipoDevolucionCatalogo GuardarTipoDevolucion(TipoDevolucionCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("TipoDevolucion Datos requeridos");

            if (datos.NPK_TipoDevolucion == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_TipoDevolucion = connection.Insert<TipoDevolucionCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoDevolucion = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<TipoDevolucionCatalogo>(datos.NPK_TipoDevolucion, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<TipoDevolucionCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoDevolucion = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public TipoDevolucionCatalogo GuardarTipoDevolucionActivo(long NPK_TipoDevolucion, int Activo, int NFK_User)
        {
            TipoDevolucionCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<TipoDevolucionCatalogo>(NPK_TipoDevolucion, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<TipoDevolucionCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region TipoEmbarque
        public List<vwTipoEmbarque> TraerTipoEmbarques(int? Activo)
        {
            var resp = new List<vwTipoEmbarque>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwTipoEmbarque>("Select * From vwTipoEmbarque with(nolock) Where Activo = IsNull(@Activo, Activo) order by TipoEmbarque", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public TipoEmbarqueCatalogo GuardarTipoEmbarque(TipoEmbarqueCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("TipoEmbarque Datos requeridos");

            if (datos.NPK_TipoEmbarque == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_TipoEmbarque = connection.Insert<TipoEmbarqueCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoEmbarque = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<TipoEmbarqueCatalogo>(datos.NPK_TipoEmbarque, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<TipoEmbarqueCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoEmbarque = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public TipoEmbarqueCatalogo GuardarTipoEmbarqueActivo(long NPK_TipoEmbarque, int Activo, int NFK_User)
        {
            TipoEmbarqueCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<TipoEmbarqueCatalogo>(NPK_TipoEmbarque, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<TipoEmbarqueCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region TipoMovimientoInventario
        public List<vwTipoMovimientoInventario> TraerTipoMovimientoInventarios(int? Activo)
        {
            var resp = new List<vwTipoMovimientoInventario>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwTipoMovimientoInventario>("Select * From vwTipoMovimientoInventario with(nolock) Where Activo = IsNull(@Activo, Activo) order by TipoMovimiento", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public TipoMovimientoInventarioCatalogo GuardarTipoMovimientoInventario(TipoMovimientoInventarioCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("TipoMovimientoInventario Datos requeridos");

            if (datos.NPK_TipoMovimientoInventario == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_TipoMovimientoInventario = connection.Insert<TipoMovimientoInventarioCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoMovimientoInventario = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<TipoMovimientoInventarioCatalogo>(datos.NPK_TipoMovimientoInventario, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<TipoMovimientoInventarioCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoMovimientoInventario = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public TipoMovimientoInventarioCatalogo GuardarTipoMovimientoInventarioActivo(long NPK_TipoMovimientoInventario, int Activo, int NFK_User)
        {
            TipoMovimientoInventarioCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<TipoMovimientoInventarioCatalogo>(NPK_TipoMovimientoInventario, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<TipoMovimientoInventarioCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region TipoPago
        public List<vwTipoPago> TraerTipoPagos(int? Activo)
        {
            var resp = new List<vwTipoPago>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwTipoPago>("Select * From vwTipoPago with(nolock) Where Activo = IsNull(@Activo, Activo) order by TipoPago", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public TipoPagoCatalogo GuardarTipoPago(TipoPagoCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("TipoPago Datos requeridos");

            if (datos.NPK_TipoPago == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_TipoPago = connection.Insert<TipoPagoCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoPago = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<TipoPagoCatalogo>(datos.NPK_TipoPago, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<TipoPagoCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoPago = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public TipoPagoCatalogo GuardarTipoPagoActivo(long NPK_TipoPago, int Activo, int NFK_User)
        {
            TipoPagoCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<TipoPagoCatalogo>(NPK_TipoPago, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<TipoPagoCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region TipoProducto
        public List<vwTipoProducto> TraerTipoProductos(int? Activo)
        {
            var resp = new List<vwTipoProducto>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwTipoProducto>("Select * From vwTipoProducto with(nolock) Where Activo = IsNull(@Activo, Activo) order by TipoProducto", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public TipoProductoCatalogo GuardarTipoProducto(TipoProductoCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("TipoProducto Datos requeridos");

            if (datos.NPK_TipoProducto == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_TipoProducto = connection.Insert<TipoProductoCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoProducto = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<TipoProductoCatalogo>(datos.NPK_TipoProducto, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<TipoProductoCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoProducto = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public TipoProductoCatalogo GuardarTipoProductoActivo(long NPK_TipoProducto, int Activo, int NFK_User)
        {
            TipoProductoCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<TipoProductoCatalogo>(NPK_TipoProducto, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<TipoProductoCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region TipoProveedor
        public List<vwTipoProveedor> TraerTipoProveedors(int? Activo)
        {
            var resp = new List<vwTipoProveedor>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwTipoProveedor>("Select * From vwTipoProveedor with(nolock) Where Activo = IsNull(@Activo, Activo) order by TipoProveedor", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public TipoProveedorCatalogo GuardarTipoProveedor(TipoProveedorCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("TipoProveedor Datos requeridos");

            if (datos.NPK_TipoProveedor == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_TipoProveedor = connection.Insert<TipoProveedorCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoProveedor = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<TipoProveedorCatalogo>(datos.NPK_TipoProveedor, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<TipoProveedorCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoProveedor = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public TipoProveedorCatalogo GuardarTipoProveedorActivo(long NPK_TipoProveedor, int Activo, int NFK_User)
        {
            TipoProveedorCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<TipoProveedorCatalogo>(NPK_TipoProveedor, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<TipoProveedorCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region TipoVenta
        public List<vwTipoVenta> TraerTipoVentas(int? Activo)
        {
            var resp = new List<vwTipoVenta>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwTipoVenta>("Select * From vwTipoVenta with(nolock) Where Activo = IsNull(@Activo, Activo) order by TipoVenta", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public TipoVentaCatalogo GuardarTipoVenta(TipoVentaCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("TipoVenta Datos requeridos");

            if (datos.NPK_TipoVenta == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_TipoVenta = connection.Insert<TipoVentaCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoVenta = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<TipoVentaCatalogo>(datos.NPK_TipoVenta, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<TipoVentaCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_TipoVenta = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public TipoVentaCatalogo GuardarTipoVentaActivo(long NPK_TipoVenta, int Activo, int NFK_User)
        {
            TipoVentaCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<TipoVentaCatalogo>(NPK_TipoVenta, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<TipoVentaCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Usuario
        public List<vwUsuarioCat> TraerUsuarios(int? Activo)
        {
            var resp = new List<vwUsuarioCat>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwUsuarioCat>("Select * From vwUsuario with(nolock) Where Activo = IsNull(@Activo, Activo) order by Usuario", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        public UsuarioCatalogo GuardarUsuario(UsuarioCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Usuario Datos requeridos");

            if (datos.NPK_Usuario == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Usuario = connection.Insert<UsuarioCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Usuario = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<UsuarioCatalogo>(datos.NPK_Usuario, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<UsuarioCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Usuario = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }

        public UsuarioCatalogo GuardarUsuarioActivo(long NPK_Usuario, int Activo, int NFK_User)
        {
            UsuarioCatalogo datos;

            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var fab = connection.Get<UsuarioCatalogo>(NPK_Usuario, tran);
                        fab.FechaModificacion = DateTime.Now;
                        fab.ModificadoPor = NFK_User;
                        fab.Activo = Activo;
                        connection.Update<UsuarioCatalogo>(fab, tran);
                        tran.Commit();
                        datos = fab;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                }
            }

            return datos;
        }

        #endregion
        #region Venta 
        public VentaCatalogo GuardarVenta(VentaCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Venta Datos requeridos");

            if (datos.NPK_Venta == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            datos.Activo = 1;
                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_Venta = connection.Insert<VentaCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Venta = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<VentaCatalogo>(datos.NPK_Venta, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<VentaCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_Venta = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }
        public List<vwVenta> TraerVentas(int? Activo)
        {
            var resp = new List<vwVenta>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwVenta>("Select * From vwVenta with(nolock) Where Activo = IsNull(@Activo, Activo) order by FechaVenta", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        #endregion
        #region Ventadetalle
        public VentadetalleCatalogo GuardarVentadetalle(VentadetalleCatalogo datos, int NFK_User)
        {
            if (datos == null)
                throw new exceptions.BusinessRuleValidationException("Ventadetalle Datos requeridos");

            if (datos.NPK_VentaDetalle == 0)
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {

                            datos.FechaCreacion = DateTime.Now;
                            datos.CreadoPor = NFK_User;
                            datos.NPK_VentaDetalle = connection.Insert<VentadetalleCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_VentaDetalle = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            else
            {
                using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
                {
                    connection.Open();

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var fab = connection.Get<VentadetalleCatalogo>(datos.NPK_VentaDetalle, tran);
                            datos.FechaModificacion = DateTime.Now;
                            datos.ModificadoPor = NFK_User;
                            datos.CreadoPor = fab.CreadoPor;
                            datos.FechaCreacion = fab.FechaCreacion;
                            connection.Update<VentadetalleCatalogo>(datos, tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            datos.NPK_VentaDetalle = 0;
                            tran.Rollback();
                            throw ex;
                        }

                    }
                }
            }
            return datos;
        }
        public List<vwVentadetalle> TraerVentasdetalle(int? NFK_Venta)
        {
            var resp = new List<vwVentadetalle>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwVentadetalle>("Select * From vwVentadetalle with(nolock) Where NFK_Venta = IsNull(@NFK_Venta, NFK_Venta) order by NPK_VentaDetalle", new { NFK_Venta }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }

        #endregion
        #region Cotizacion
        public List<vwCotizacion> TraerCotizacion(int? Activo)
        {
            var resp = new List<vwCotizacion>();
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                try
                {
                    connection.Open();
                    resp = connection.Query<vwCotizacion>("Select * From vwCotizacion with(nolock) Where Activo = IsNull(@Activo, Activo) order by FechaCotizacion", new { Activo }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resp;
        }
        #endregion
    }
}
