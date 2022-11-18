using Microsoft.AspNetCore.Mvc;
using ToDoWebApi.Models;
using ToDoWebApi.Services;

namespace ToDoWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BranchController : Controller
    {
        public BranchController()
        { }

        //Get all
        [HttpGet]
        public ActionResult<List<Branch>> GetAll() => BranchServices.GetAll();

        //Get by ID 
        [HttpGet("{id}")]
        public ActionResult<Branch> Get(int id)
        {
            var branch = BranchServices.Get(id);

            if(branch == null)
                return NotFound();

            return branch;
        }
        //Post
        [HttpPost]
        public IActionResult Create(Branch branch)
        {
            BranchServices.Add(branch);
            return CreatedAtAction(nameof(Create), new { id = branch.ID }, branch);
        }

        //Put
        [HttpPut]
        public IActionResult Update(int id, Branch branch)
        {
            if (id != branch.ID)
                return BadRequest();

            var existingBranch = BranchServices.Get(id);
            if(existingBranch is null)
            {
                return NotFound();
            }    
            BranchServices.Update(branch);
            return NoContent();
        }
        //Delete
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var branch = BranchServices.Get(id);
            if (branch is null)
                return NotFound();
            BranchServices.Delete(id);
            return NoContent();
        }

    }
}
