using ToDoWebApi.Models;

namespace ToDoWebApi.Services
{
    public static class BranchServices
    {
        static List<Branch> Branches { get; }
        static int nextIndex = 4;
        static BranchServices()
        {
            Branches = new List<Branch>
            {
                new Branch
                {
                    ID = 1,
                    Name = "Codetelliegence",
                    IsActive = true,
                },
                new Branch
                {
                    ID = 2,
                    Name ="Younglings Africa",
                    IsActive = true,
                },
                new Branch
                {
                    ID = 3,
                    Name = "Bakgotsi",
                    IsActive = false,
                }
            };

        }
        public static List<Branch> GetAll() => Branches;
        public static Branch? Get (int id) => Branches.FirstOrDefault(x => x.ID == id);
        public static void Add(Branch branch)
        {
            branch.ID = nextIndex++;
            Branches.Add(branch);
        }
        public static void Delete(int id)
        {
            var branch = Get(id);
            if(branch is null)
            {
                return;
            }
            Branches.Remove(branch);

        }
        public static void Update(Branch branch)
        {
            var index = Branches.FindIndex(b=> b.ID == branch.ID);
            if (index == -1)
                return;
            Branches[index] = branch;
        }
    }
}
