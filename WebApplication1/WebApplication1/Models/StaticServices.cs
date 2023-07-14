namespace WebApplication1.Models
{
    public class StaticServices : IServices
    {


        private static List<Door> doorList = new List<Door>();

        private static int nextId = 1;



        public Response Add(double x, double y)
        {
            var door = new Door()
            {
                Id = nextId++,
                X = x,
                Y = y,
            };

            doorList.Add(door);

            return new Response("Eleman eklendi.", door);
        }

        public Response Delete(int id)
        {
            var deletedDoor = doorList.FirstOrDefault(x => x.Id == id);
            if (deletedDoor != null)
            {
                int silinen = id;
                doorList.Remove(deletedDoor);
                return new Response(silinen + " id'li eleman silindi.", deletedDoor);
            }
            else
            {
                return new Response("Eleman bulunamadi.", deletedDoor);
            }
        }

        public List<Door> GetAll()
        {
            return doorList;
        }

        public Response Read(int id)
        {
            var door = doorList.FirstOrDefault(x => x.Id == id);
            if (door != null)
            {
                return new Response("Eleman basariyla getirildi.", door);
            }
            else
            {
                return new Response("Eleman yok.", door);
            }
        }

        public Response Update(int id, double? x = null, double? y = null)
        {
            var updatedDoor = doorList.FirstOrDefault(d => d.Id == id);

            Door tempDoor = updatedDoor;

            if (updatedDoor != null)
            {
                if (x != null && y == null)
                {
                    updatedDoor.Y = tempDoor.Y;
                    updatedDoor.X = x;
                }
                if (x == null && y != null)
                {
                    updatedDoor.X = tempDoor.X;
                    updatedDoor.Y = y;
                }
                if (y != null && x != null)
                {
                    updatedDoor.X = x;
                    updatedDoor.Y = y;
                }
                return new Response(id + " id'li eleman güncellendi.", updatedDoor);
            }
            else
            {
                return new Response("Eleman bulunamadı", null);
            }
        }
    }
}
