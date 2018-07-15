using System.Linq;

namespace MVC5Course.Models
{   
	public  class ClientRepository : EFRepository<Client>, IClientRepository
	{
	    public Client Find(int id)
	    {
	        return All().FirstOrDefault(x => x.ClientId == id);
	    }

	    public IQueryable<Client> SearchFirstName(string keyword)
	    {
	        return !string.IsNullOrEmpty(keyword) 
	            ? All().Where(x => x.FirstName.Contains(keyword)) 
	            : All();
	    } 

        public override void Delete(Client entity)
        {
            entity.IsDeleted = true;
        }

	    public override IQueryable<Client> All()
	    {
	        return base.All().Where(x => x.IsDeleted == false);
	    }

	    public override void Add(Client entity)
	    {
	        entity.IsDeleted = false;
	        base.Add(entity);
	    }
	}

	public  interface IClientRepository : IRepository<Client>
	{

	}
}