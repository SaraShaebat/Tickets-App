using DataAccessLayer.Entities;

namespace BusinessLogicLayer
{
    public static class UserMapper
    {
        // Convert User entity to UserDTO
        //public static UserDTO ToUserDTO(this User user)
        //{
        //    return new UserDTO
        //    {
        //        Id = user.Id,
        //        FullName = user.FullName,
        //        Email = user.Email,
        //        Password = user.Password,
        //        Phone = user.Phone,
        //        IsActive = user.IsActive,
        //        CompanyId = user.CompanyId
        //    };
        //}

        // Convert UserDTO to User entity
        public static User ToUserEntity(this UserDTO userDto)
        {
            return new User
            {
                Id = userDto.Id, // Include Id if updating an existing entity
                FullName = userDto.FullName,
                Email = userDto.Email,
                Password = userDto.Password,
                Phone = userDto.Phone,
                IsActive = userDto.IsActive,
                CompanyId = userDto.CompanyId
            };
        }

        // Update existing User entity with values from UserDTO
        public static void UpdateUserEntity(this UserDTO userDto, User user)
        {
            user.FullName = userDto.FullName;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            user.Phone = userDto.Phone;
            user.IsActive = userDto.IsActive;
            user.CompanyId = userDto.CompanyId;
        }

        // Convert User entity to UserResource
        public static UserResource ToUserResource(this User user)
        {
            return new UserResource
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone,
                IsActive = user.IsActive,
                CompanyId = user.CompanyId
            };
        }
    }
}
