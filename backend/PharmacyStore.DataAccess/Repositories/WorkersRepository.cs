using Microsoft.EntityFrameworkCore;
using PharmacyStore.Core.Models;
using PharmacyStore.DataAccess.Entities;

namespace PharmacyStore.DataAccess.Repositories
{
    public class WorkersRepository : IWorkerRepository
    {
        private readonly PharmacyDBContext _context;

        public WorkersRepository(PharmacyDBContext context)
        {
            _context = context;
        }

        public async Task<List<Worker>> GetAllWorkers()
        {
            var workerEntities = await _context.pharmacists.AsNoTracking().ToListAsync();

            var workers = workerEntities.Select(b => Worker.Create(b.Worker_Id, b.Last_Name, b.First_Name, b.Middle_Name, b.Employment_Date, b.Birth_Date, b.Education).worker).ToList();

            return workers;
        }

        public async Task<Guid> Create(Worker worker)
        {
            var workerEntitie = new Worker_Entity
            {
                Worker_Id = worker.Worker_Id,
                Last_Name = worker.Last_Name,
                First_Name = worker.First_Name,
                Middle_Name = worker.Middle_Name,
                Employment_Date = worker.Employment_Date,
                Birth_Date = worker.Birth_Date,
                Education = worker.Education,
            };

            await _context.pharmacists.AddAsync(workerEntitie);
            await _context.SaveChangesAsync();

            return workerEntitie.Worker_Id;
        }

        public async Task<Guid> Update(Guid id, string Last_Name, string First_Name, string Middle_Name, DateTime Employment_Date, DateTime Birth_Date, string Education)
        {
            await _context.pharmacists
                .Where(b => b.Worker_Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Last_Name, b => Last_Name)
                .SetProperty(b => b.First_Name, b => First_Name)
                .SetProperty(b => b.Middle_Name, b => Middle_Name)
                .SetProperty(b => b.Employment_Date, b => Employment_Date)
                .SetProperty(b => b.Birth_Date, b=> Birth_Date)
                .SetProperty(b=>b.Education, b=> Education));
            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.pharmacists.Where(b => b.Worker_Id == id).ExecuteDeleteAsync();
            return id;
        }


        public async Task<Worker> GetWorkerById(Guid id)
        {
            var workerEntity = await _context.pharmacists.FindAsync(id);

            var worker = Worker.Create(workerEntity.Worker_Id,
                                       workerEntity.Last_Name,
                                       workerEntity.First_Name,
                                       workerEntity.Middle_Name,
                                       workerEntity.Employment_Date,
                                       workerEntity.Birth_Date,
                                       workerEntity.Education).worker;
            return worker;
        }
    }
}
