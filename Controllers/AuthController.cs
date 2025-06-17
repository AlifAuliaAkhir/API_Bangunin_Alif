using bangun.Models;
using Microsoft.AspNetCore.Mvc;
using bangun.Data;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using bangun.Enums;

namespace bangun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if (user.Role == UserRole.Admin)
                return BadRequest("Tidak diizinkan membuat akun admin lewat endpoint ini.");

            if (await _context.Users.AnyAsync(u => u.Nama == user.Nama))
                return BadRequest("Username sudah digunakan.");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("Berhasil registrasi.");
        }

        // Ganti PW Admin
        [HttpPost("ganti-password")]
        public async Task<IActionResult> GantiPassword([FromBody] Login model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Nama == model.Nama);
            if (user == null)
                return NotFound("User tidak ditemukan.");

            if (user.Role != UserRole.Admin)
                return Unauthorized("Hanya admin yang bisa ganti password lewat sini.");

            user.Password = model.Password;
            await _context.SaveChangesAsync();
            return Ok("Password berhasil diganti.");
        }

        [HttpPost("ganti-password-user")]
        public async Task<IActionResult> GantiPasswordUser([FromBody] GantiPasswordUser model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Nama == model.Nama);
            if (user == null)
                return NotFound("User tidak ditemukan.");

            user.Password = model.PasswordBaru;
            await _context.SaveChangesAsync();

            return Ok("Password berhasil diganti.");
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(Login model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Nama == model.Nama && u.Password == model.Password);
            if (user == null)
                return Unauthorized("Login gagal.");

            // Generate JWT
            var claims = new[]
            {
             new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
             new Claim(ClaimTypes.Name, user.Nama.ToString()),
             new Claim(ClaimTypes.Role, user.Role.ToString())
             };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this_is_a_very_strong_secret_key_123459"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                user.Id,
                user.Nama,
                user.Role
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}


