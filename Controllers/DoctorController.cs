using AutoMapper;
using HospitalTest.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HospitalTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController(HospitalContext ctx, IMapper mapper) : ControllerBase
{
    // GET: api/<DoctorController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        throw new NotImplementedException();
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
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<DoctorController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
