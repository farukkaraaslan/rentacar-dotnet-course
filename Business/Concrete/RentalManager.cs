using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Core.Utilities.Constants;
using Business.Rules;
using Core.Exceptions;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;

namespace Business.Concrete
{
    public class RentalManager :IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly ICarService _carService;
        private readonly IPaymentService _paymentService;
        private readonly RentalBusinessRules _rentalBusinessRules;
        private readonly IMapper _mapper;
        private readonly IInvoiceService _invoiceService;
        public RentalManager(
            IRentalDal rentalDal,
            ICarService carService, 
            RentalBusinessRules rentalBusinessRules,
            IMapper mapper,
            IPaymentService paymentService,
            IInvoiceService invoiceService
            )
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _rentalBusinessRules = rentalBusinessRules;
            _mapper = mapper;   
            _paymentService=paymentService;
            _invoiceService=invoiceService;
        }
        public List<Rental> GetAll()
        {
           return  _rentalDal.GetAll();
        }

        public Rental GetById(int id)
        {
            return _rentalDal.Get(r => r.Id == id);
        }

        public Rental GetByCar(int carId)
        {
            return _rentalDal.Get(r => r.CarId == carId);
        }

        public void Add(RentalDto rentalDto)
        {
            //!!!!! Maplee işlemi ell ile yapıldı !!!!!
            //var rental = new Rental();
            //rental.CarId= rentalDto.CarId;
            //rental.DailyPrice=rentalDto.DailyPrice;
            //rental.RentedForDays=rentalDto.RentedForDays;


            //!!!!Mapleme işlemi AutoMapper paketi yüklenerek yapıldı!!!!
            var rental = _mapper.Map<Rental>(rentalDto);

            _rentalBusinessRules.CheckIfCarAvailable(_carService.GetById(rental.CarId).State);
            rental.TotalPrice = rental.RentedForDays * rental.DailyPrice;
            rental.RentalStartDate = DateTime.Now;
            rental.RentalEndDate = null;
            //Payment
            _rentalBusinessRules.ValidatePaymentDto(rentalDto.Payment);
            rentalDto.Payment.Price = rental.TotalPrice;
            _paymentService.ProcessPayment(rentalDto.Payment);


            _rentalDal.Add(rental);
            _carService.ChanceState(rental.CarId, CarState.Rented);
            //Invoice
            AddInvoice(rentalDto, rental);
          

        }

        public void Update(Rental rental)
        {
           _rentalDal.Update(rental);
        }

        public void Delete(int id)
        {
            var rental = GetById(id);
            _carService.ChanceState(rental.CarId, CarState.Available);
            _rentalDal.Delete(id);
            
        }

        private void AddInvoice(
      
            RentalDto rentalDto, 
           Rental rental
            )
        {
            var invoice = new Invoice();
            var carDetail = _carService.GetCarDetailById(rental.CarId);
            invoice.CardHolder = rentalDto.Payment.CardHolder;
            invoice.BrandName = carDetail.BrandName;
            invoice.Plate = carDetail.Plate;
            invoice.ModelYear = carDetail.ModelYear;
            invoice.DailyPrice = rental.DailyPrice;
            invoice.RentedForDays = rental.RentedForDays;
            invoice.TotalPrice = rental.TotalPrice;
            invoice.RentedAt = rental.RentalStartDate;
            invoice.ImagePath = carDetail.Image;
            //if (carDetail.Image==null )
            //{
            //    invoice.ImagePath = "default-image.png";
            //}
            _invoiceService.Add(invoice);
        }
    }
}
