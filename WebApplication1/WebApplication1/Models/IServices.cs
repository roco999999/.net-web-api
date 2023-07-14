namespace WebApplication1.Models
{
    public interface IServices
    {

        Response Add(double x, double y);
        Response Delete(int id);
        Response Update(int id, double? x = null, double? y = null);
        Response Read(int id);
        List<Door> GetAll();

    }
}
