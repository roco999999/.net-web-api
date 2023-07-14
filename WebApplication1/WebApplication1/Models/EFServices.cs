using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Models
{
    
    public class EFServices : IServices
    {
        private readonly MyDbContext _dbContext;

        public EFServices()
        {
            _dbContext = new MyDbContext();

        }

        public EFServices(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Response Add(double x, double y)
        {
            var door = new Door
            {
                X = x,
                Y = y
            };

            _dbContext.Doors.Add(door);
            _dbContext.SaveChanges();

            return new Response("Eleman eklendi.", door);
        }

        public Response Delete(int id)
        {
            var door = _dbContext.Doors.Find(id);
            if (door != null)
            {
                _dbContext.Doors.Remove(door);
                _dbContext.SaveChanges();
                return new Response("Eleman silindi.", null);
            }

            return new Response("Eleman bulunamadı.", null);
        }

        public List<Door> GetAll()
        {
            return _dbContext.Doors.ToList();
        }

        public Response Read(int id)
        {
            var door = _dbContext.Doors.Find(id);
            if (door != null)
            {
                return new Response("Veri bulundu.", door);
            }

            return new Response("Veri bulunamadı.", null);
        }

        public Response Update(int id, double? x = null, double? y = null)
        {
            var door = _dbContext.Doors.Find(id);
            if (door != null)
            {
                if (x.HasValue)
                {
                    door.X = x.Value;
                }

                if (y.HasValue)
                {
                    door.Y = y.Value;
                }

                _dbContext.SaveChanges();
                return new Response("Eleman güncellendi.", null);
            }

            return new Response("Eleman bulunamadı.", null);
        }
    }
}