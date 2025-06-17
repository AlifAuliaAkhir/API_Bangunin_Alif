using bangun.Data;
using bangun.Dtos.ProyekDtos;
using bangun.Helpers;
using bangun.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bangun.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyekController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProyekController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProyekReadDto>>> GetAll()
        {
            var data = await _context.Proyeks
                .Include(p => p.ProyekProducts)
                .ThenInclude(pp => pp.Product)
                .ToListAsync();

            var result = data.Select(p => new ProyekReadDto
            {
                Id = p.Id,
                Nama = p.Nama,
                IsSelesai = p.IsSelesai,
                ProyekProducts = p.ProyekProducts.Select(pp => new ProyekProductDetailDto
                {
                    ProductId = pp.ProductId,
                    NamaProduk = pp.Product?.Nama_Product ?? "",
                    Harga = pp.Product?.Harga ?? 0,
                    Jumlah = pp.Jumlah,
                    SatuanBarang = Enum.Parse<bangun.Enums.SatuanEnum>(pp.Product?.SatuanBarang ?? "Pcs")
                }).ToList()
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProyekCreateDto dto)
        {
            var proyek = new Proyek
            {
                Nama = dto.Nama,
                IsSelesai = dto.IsSelesai,
                ProyekProducts = dto.ProyekProducts.Select(p => new ProyekProduct
                {
                    ProductId = p.ProductId,
                    Jumlah = p.Jumlah
                }).ToList()
            };

            _context.Proyeks.Add(proyek);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = proyek.Id }, proyek);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ProyekUpdateDto dto)
        {
            var proyek = await _context.Proyeks.FirstOrDefaultAsync(p => p.Id == id);

            if (proyek == null)
                return NotFound();

            proyek.IsSelesai = dto.IsSelesai;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var proyek = await _context.Proyeks
                .Include(p => p.ProyekProducts)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (proyek == null)
                return NotFound();

            _context.Proyeks.Remove(proyek);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{id}/pdf")]
        public async Task<IActionResult> PrintToPDF(int id)
        {
            var proyek = await _context.Proyeks
                .Include(p => p.ProyekProducts)
                .ThenInclude(pp => pp.Product)
                .FirstOrDefaultAsync(p => p.Id == id && p.IsSelesai);

            if (proyek == null)
                return NotFound("Proyek tidak ditemukan atau belum selesai.");

            var pdfBytes = PDFGenerator.Generate(proyek);
            return File(pdfBytes, "application/pdf", $"Proyek_{proyek.Nama}.pdf");
        }

        [HttpGet("selesai")]
        public async Task<ActionResult<IEnumerable<ProyekReadDto>>> GetProyekSelesai()
        {
            var proyekList = await _context.Proyeks
                .Where(p => p.IsSelesai)
                .Include(p => p.ProyekProducts)
                .ThenInclude(pp => pp.Product)
                .ToListAsync();

            return Ok(MapToDtoList(proyekList));
        }

        [HttpGet("belum-selesai")]
        public async Task<ActionResult<IEnumerable<ProyekReadDto>>> GetProyekBelumSelesai()
        {
            var proyekList = await _context.Proyeks
                .Where(p => !p.IsSelesai)
                .Include(p => p.ProyekProducts)
                .ThenInclude(pp => pp.Product)
                .ToListAsync();

            return Ok(MapToDtoList(proyekList));
        }

        [HttpPost("{id}/add-product")]
        public async Task<ActionResult> AddProductToProyek(int id, [FromBody] AddProductToProyekDto dto)
        {
            var proyek = await _context.Proyeks
                .Include(p => p.ProyekProducts)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (proyek == null)
                return NotFound("Proyek tidak ditemukan");

            var existing = proyek.ProyekProducts.FirstOrDefault(pp => pp.ProductId == dto.ProductId);
            if (existing != null)
            {
                existing.Jumlah += dto.Jumlah;
            }
            else
            {
                proyek.ProyekProducts.Add(new ProyekProduct
                {
                    ProductId = dto.ProductId,
                    Jumlah = dto.Jumlah
                });
            }

            await _context.SaveChangesAsync();
            return Ok("Produk berhasil ditambahkan ke proyek.");
        }

        private static List<ProyekReadDto> MapToDtoList(List<Proyek> proyekList) =>
            proyekList.Select(p => new ProyekReadDto
            {
                Id = p.Id,
                Nama = p.Nama,
                IsSelesai = p.IsSelesai,
                ProyekProducts = p.ProyekProducts.Select(pp => new ProyekProductDetailDto
                {
                    ProductId = pp.ProductId,
                    NamaProduk = pp.Product?.Nama_Product ?? "",
                    Harga = pp.Product?.Harga ?? 0,
                    Jumlah = pp.Jumlah,
                    SatuanBarang = Enum.Parse<bangun.Enums.SatuanEnum>(pp.Product?.SatuanBarang ?? "Pcs")
                }).ToList()
            }).ToList();
    }
}