using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Npgsql;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DoorController : ControllerBase
    {
        

        public DBServices _dbServices = new DBServices();
        public StaticServices _staticServices = new StaticServices();
        public EFServices _efServices = new EFServices();

        [HttpDelete("{id}")]
        public Response Delete(int flag,int id)
        {
            Response response = new Response("Gecersiz flag (1 - db \n2- static \n3- entityframework)", null);
            if (flag == 1) //  flag = 1 for database services flag = 2 fo static flag = 3 for efservice
            {
                response = _dbServices.Delete(id);
            }
            else if (flag == 2)
            {
                response = _staticServices.Delete(id);
            }
            else if (flag == 3)
            {
                response = _efServices.Delete(id);
            }
            
            return response;
        }

        [HttpPut("{id}")]
        public Response Update(int flag,int id, double? x = null, double? y = null)
        {
            Response response = new Response("Gecersiz flag (1 - db \n2- static \n3- entityframework)", null);
            if (flag == 1) //  flag = 1 for database services flag = 2 fo static flag = 3 for efservice
            {
                response = _dbServices.Update(id,x, y);
            }
            else if (flag == 2)
            {
                response = _staticServices.Update(id, x, y);
            }
            else if (flag == 3)
            {
                response = _efServices.Update(id, x, y);
            }
            return response;
        }

        [HttpPost]
        public Response Add(int flag ,double x, double y)
        {
            Response response = new Response("Gecersiz flag (1 - db \n2- static \n3- entityframework)", null);
            if (flag == 1) //  flag = 1 for database services flag = 2 fo static flag = 3 for efservice
            {
                response = _dbServices.Add(x, y);
            }
            else if (flag == 2)
            {
                response = _staticServices.Add(x, y);
            }
            else if (flag == 3)
            {
                response = _efServices.Add(x, y);
            }
                return response;
        }
       

        [HttpGet]
        public List<Door> GetAll(int flag)
        {
            List<Door> doors= new List<Door>();

            if (flag == 1) //  flag = 1 for database services flag = 2 fo static flag = 3 for efservice
            {
                doors = _dbServices.GetAll();
            }
            else if (flag == 2)
            {
                doors = _staticServices.GetAll();
            }
            else if (flag == 3)
            {
                doors = _efServices.GetAll();
            }
            return doors;
        }

        [HttpGet("{id}")]
        public Response Read(int flag ,int id)
        {
            Response response= new Response("Gecersiz flag (1 - db \n2- static \n3- entityframework)", null);
            if (flag == 1) //  flag = 1 for database services flag = 2 fo static flag = 3 for efservice
            {
                response = _dbServices.Read(id);
            }
            else if (flag == 2)
            {
                response = _staticServices.Read(id);
            }
            else if (flag == 3)
            {
                response = _efServices.Read(id);
            }
            return response;
        }



    }
}
/*
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorController : ControllerBase
    {
        public IServices _dbServices;
        public IServices _staticServices;
        public IServices _efServices;

        public DoorController(DBServices dbServices, StaticServices staticServices, EFServices efServices)
        {
            _dbServices = dbServices;
            _staticServices = staticServices;
            _efServices = efServices;
        }

        [HttpDelete("{flag}/{id}")]
        public Response Delete(int flag, int id)
        {
            IServices services = GetServices(flag);
            return services.Delete(id);
        }

        [HttpPut("{flag}/{id}")]
        public Response Update(int flag, int id, double? x = null, double? y = null)
        {
            IServices services = GetServices(flag);
            return services.Update(id, x, y);
        }

        [HttpPost("{flag}")]
        public Response Add(int flag, double x, double y)
        {
            IServices services = GetServices(flag);
            return services.Add(x, y);
        }

        [HttpGet("{flag}")]
        public Response GetAll(int flag)
        {
            IServices services = GetServices(flag);
            var doors = services.GetAll();
            return new Response("Veriler alındı.", null);
        }

        [HttpGet("{flag}/{id}")]
        public Response Read(int flag, int id)
        {
            IServices services = GetServices(flag);
            return services.Read(id);
        }

        private IServices GetServices(int flag)
        {
            IServices services;
            if (flag == 1)
            {
                services = _dbServices;
            }
            else if (flag == 2)
            {
                services = _staticServices;
            }
            else if (flag == 3)
            {
                services = _efServices;
            }
            else
            {
                // Eğer flag 1, 2 veya 3 değilse hata durumunu döndür
                return null;
            }

            return services;
        }
    }
}

*/