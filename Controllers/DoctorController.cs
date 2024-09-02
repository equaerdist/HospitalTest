using AutoMapper;
using AutoMapper.QueryableExtensions;
using HospitalTest.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace HospitalTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController(HospitalContext ctx, IMapper mapper) : ControllerBase
{
    private const string _asc = "asc";
    private Expression<Func<Doctor, object?>> GetOrderSelector(string orderProp)
    {
        return orderProp switch
        {
            "area_id" => d => d.Area == null ? 1 : d.Area.Id,
            "specialization_id" => d => d.SpecializationId,
            "cabinet_id" => d => d.CabinetId,
            "fullname" => d => d.FullName, 
            _ => d => d.Id
        };
}
    // GET: api/<DoctorController>
    [HttpGet]
    public async Task<IActionResult> GetDoctors(
        [FromQuery] string orderProp, [FromQuery] string order, 
        [FromQuery] int page, [FromQuery] int pageSize)
    {
        var orderSelector = GetOrderSelector(orderProp);
        var doctors = ctx.Doctors.AsQueryable();
        if(order == _asc)
            doctors = doctors.OrderBy(orderSelector);
        else
            doctors = doctors.OrderByDescending(orderSelector);
        return Ok(await doctors
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ProjectTo<GetDoctorDto>(mapper.ConfigurationProvider)
            .ToArrayAsync());
    }
    // GET api/<DoctorController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctorById(long id)
    {
        var doctor = await ctx.Doctors.FirstOrDefaultAsync(s => s.Id == id);
        if(doctor is null)
            return NotFound();
        var doctorDto = mapper.Map<GetSingleDoctorDto>(doctor);
        return Ok(doctorDto);
    }

    // POST api/<DoctorController>
    [HttpPost]
    public async Task<IActionResult> AddDoctor([FromBody] AddDoctorDto newDoctor)
    {
        var dbDoctor = mapper.Map<Doctor>(newDoctor);
        await ctx.Doctors.AddAsync(dbDoctor);
        await ctx.SaveChangesAsync();
        var doctorDto = mapper.Map<GetSingleDoctorDto>(dbDoctor); 
        return CreatedAtAction(nameof(GetDoctorById), new { id = dbDoctor.Id }, doctorDto);
    }

    // PUT api/<DoctorController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDoctor(long id, [FromBody] UpdateDoctorDto editedDoctor)
    {
        var doctorFromDb = await ctx.Doctors.FirstOrDefaultAsync(s => s.Id == id);
        if(doctorFromDb is null) return NotFound();
        mapper.Map(editedDoctor, doctorFromDb);
        await ctx.SaveChangesAsync();
        return NoContent();
    }

    // DELETE api/<DoctorController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(long id)
    {
        await ctx.Doctors.Where(d => d.Id == id).ExecuteDeleteAsync();
        return NoContent();
    }
}
