namespace MyLazaDaks.Controllers.USER_CONTROLLER;

    public class UserController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        [HttpPost]
        [Route("AddNewUser")]
        public async Task<IActionResult> CreateNewUser(User user)
        {

            await _unitOfWork.Users.AddNewUser(user);
            await _unitOfWork.CompleteAsync();

            return Ok(user);

        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsersList()
        {
            var user = await _unitOfWork.Users.GetAllUsers();

            return Ok(user);

        }


        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {


            var validate = await _unitOfWork.Users.DeleteUser(id);

            if (validate == false)
            {
                return BadRequest("Delete failed!");
            }
            await _unitOfWork.CompleteAsync();

            return Ok("Successfully deleted!");

        }


        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {

            var validate = await _unitOfWork.Users.UpdateUser(user);

            if (validate == false)
            {
                return BadRequest("Update failed!");
            }
            await _unitOfWork.CompleteAsync();

            return Ok("Successfully updated!");

        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById([FromQuery] int id)
        {
            var customer = await _unitOfWork.Users.GetAllUserById(id);

            return Ok(customer);

        }

    }

