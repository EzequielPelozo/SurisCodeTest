using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestSurisCode.Models;
using TestSurisCode.Models.Dtos;
using TestSurisCode.Repository;
using TestSurisCode.Repository.IRepository;

namespace TestSurisCode.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _ctRepo;
        private readonly IMapper _mapper;

        public ReservationController(IReservationRepository ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetReservations()
        {
            var reservationList = _ctRepo.GetReservations();
            var reservationListDto = new List<ReservationDto>();

            foreach (var reservation in reservationList)
            {
                reservationListDto.Add(_mapper.Map<ReservationDto>(reservation));
            }

            return Ok(reservationListDto);
        }

        [HttpGet("{id:int}", Name = "GetReservation")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetReservation(int id)
        {
            var reservation = _ctRepo.GetReservation(id);

            if (reservation is null)
            {
                return NotFound();
            }

            var reservationDto = _mapper.Map<ReservationDto>(reservation);

            return Ok(reservationDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateReservation([FromBody] CreateReservationDto createReservationDto)
        {

            if (!ModelState.IsValid || createReservationDto is null)
            {
                return BadRequest(ModelState);
            }
            // Verifica si ya existe una reserva en ese mismo día y horario
            if (_ctRepo.ExistReservation(createReservationDto.Date))
            {
                return BadRequest("Ya existe una reserva en ese horario y horario.");
            }
            // Verifica si el cliente ya tiene una reserva en el mismo dia
            if (_ctRepo.sameClientExists(createReservationDto.ClientName, createReservationDto.Date))
            {
                return BadRequest("El cliente ya tiene una reserva en este día.");
            }

            var reservation = _mapper.Map<Reservation>(createReservationDto);

            if (!_ctRepo.CreateReservation(reservation))
            {
                ModelState.AddModelError("", $"Something is wrong with add register");
                return StatusCode(404, ModelState);
            }
            return CreatedAtRoute("GetReservation", new { id = reservation.Id }, reservation);
        }
    }
}
