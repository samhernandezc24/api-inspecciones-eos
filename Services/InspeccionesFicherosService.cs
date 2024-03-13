using API.Inspecciones.Models;
using API.Inspecciones.Persistence;
using System.Data.Entity;
using System.Security.Claims;
using Workcube.Libraries;

namespace API.Inspecciones.Services
{
    public class InspeccionesFicherosService
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _root;

        public InspeccionesFicherosService(Context context, IWebHostEnvironment root)
        {
            _context    = context;
            _root       = root;
        }

        public async Task Create(dynamic data, ClaimsPrincipal user)
        {
            string fileBase64       = Globals.ToString(data.fileBase64);
            string fileExtension    = "." + Globals.ToString(data.fileExtension);
            string filePath         = FileManager.GetNamePath(fileExtension);

            var objTransaction = _context.Database.BeginTransaction();

            InspeccionFichero objModel = new InspeccionFichero();

            objModel.IdInspeccionFichero  = Guid.NewGuid().ToString();
            objModel.Path                 = filePath;
            objModel.IdInspeccion         = Globals.ParseGuid(data.idInspeccion);
            objModel.InspeccionFolio      = Globals.ToString(data.inspeccionFolio);
            objModel.Orden                = 0;
            objModel.SetCreated(Globals.GetUser(user));

            _context.InspeccionesFicheros.Add(objModel);
            await _context.SaveChangesAsync();

            string directory = _root.ContentRootPath + "\\Ficheros\\InspeccionesFicheros\\";

            if (!FileManager.ValidateExtension(fileExtension)) { throw new AppException(ExceptionMessage.CAST_002); }

            FileManager.ValidateDirectory(directory);

            await FileManager.SaveFileBase64(fileBase64, directory + objModel.Path);

            objTransaction.Commit();
        }     

        public async Task Delete(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();

            var idInspeccionFichero = Globals.ParseGuid(data.idInspeccionFichero);

            InspeccionFichero objModel = await _context.InspeccionesFicheros.FindAsync(idInspeccionFichero);

            if (objModel.Deleted) { throw new ArgumentException("La foto ya ha había sido eliminada anteriormente"); }

            objModel.Deleted = true;
            objModel.SetUpdated(Globals.GetUser(user));

            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
        
        public async Task<dynamic> List(string idInspeccion)
        {
            return await _context.InspeccionesFicheros.AsNoTracking().Where(x => x.IdInspeccion == idInspeccion && !x.Deleted).OrderBy(x => x.CreatedFecha).ToListAsync();
        }

        public async Task Update(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();

            var idInspeccionFichero = Globals.ParseGuid(data.idInspeccionFichero);

            InspeccionFichero objModel = await _context.InspeccionesFicheros.FindAsync(idInspeccionFichero);

            objModel.SetUpdated(Globals.GetUser(user));

            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
    }
}
