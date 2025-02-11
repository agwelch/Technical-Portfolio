using System;
using System.Linq;
using System.Net.Mail;
using System.Collections.Generic;

namespace BuffTeksApartment
{
    public class PackageManager
    {
        private readonly ApplicationDbContext _context;

        public PackageManager()
        {
            _context = new ApplicationDbContext();
            _context.Database.EnsureCreated();
        }

        public void AddPackage(string residentName, string postalService, DateTime deliveryDate)
        {
            var package = new Package
            {
                ResidentName = residentName,
                PostalService = postalService,
                DeliveryDate = deliveryDate,
                IsPickedUp = false
            };
            _context.Packages.Add(package);
            _context.SaveChanges();
            SendEmailNotification(residentName);
        }

        public void RemovePackage(string residentName)
        {
            var packages = _context.Packages.Where(p => p.ResidentName == residentName && !p.IsPickedUp).ToList();
            _context.Packages.RemoveRange(packages);
            _context.SaveChanges();
        }

        public void AddUnknownPackage(string ownerName, string postalService, DateTime deliveryDate)
        {
            var unknownPackage = new Package
            {
                ResidentName = ownerName,
                PostalService = postalService,
                DeliveryDate = deliveryDate,
                IsPickedUp = false
            };
            _context.Packages.Add(unknownPackage);
            _context.SaveChanges();
        }

        public void MarkPackageAsPickedUp(string residentName, DateTime deliveryDate)
        {
            var package = _context.Packages.FirstOrDefault(p => p.ResidentName == residentName && p.DeliveryDate == deliveryDate && !p.IsPickedUp);
            if (package != null)
            {
                package.IsPickedUp = true;
                _context.SaveChanges();
            }
        }

        public List<Package> GetPackageHistory(string unitNumber, string residentName)
        {
            return _context.Packages.Where(p => p.ResidentName == residentName).ToList();
        }

        private void SendEmailNotification(string residentName)
        {
            try
            {
                MailMessage mail = new MailMessage("agwelch1@buffs.wtamu.edu", $"{residentName}@buffs.wtamu.edu");
                mail.Subject = "Package Delivered";
                mail.Body = "Your package has been delivered to the leasing office.";

                SmtpClient client = new SmtpClient("smtp.office365.com");
                client.Port = 587; 
                client.Credentials = new System.Net.NetworkCredential("agwelch1@buffs.wtamu.edu", "Samson2908!$");
                client.EnableSsl = true;

                client.Send(mail);
            }
            catch (SmtpException smtpEx)
            {
                Console.WriteLine($"SMTP error: {smtpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
            }
        }
    }
}
