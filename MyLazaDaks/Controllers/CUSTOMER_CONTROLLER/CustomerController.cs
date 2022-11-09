
namespace MyLazaDaks.Controllers;

    public class CustomerController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomerList()
        {
            var customer = await _unitOfWork.Customers.GetAllCustomer();

            return Ok(customer);

        }


        [HttpPost]
        [Route("AddNewCustomer")]
        public async Task<IActionResult> CreateNewCustomer(Customer customer)
        {

            await _unitOfWork.Customers.AddNewCustomer(customer);
            await _unitOfWork.CompleteAsync();

            return Ok(customer);

        }


        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {


            var validate = await _unitOfWork.Customers.DeleteCustomer(id);

            if (validate == false)
            {
                return BadRequest("Delete failed!");
            }
            await _unitOfWork.CompleteAsync();

            return Ok("Successfully deleted!");

        }

        [HttpGet]
        [Route("GetCustomersById")]
        public async Task<IActionResult> GetCustomerById([FromQuery] int id)
        {
            var customer = await _unitOfWork.Customers.GetAllCustomerById(id);

            return Ok(customer);

        }


        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {


            var validate = await _unitOfWork.Customers.UpdateCustomer(customer);

            if (validate == false)
            {
                return BadRequest("Update failed!");
            }
            await _unitOfWork.CompleteAsync();

            return Ok("Successfully updated!");

        }


    }

