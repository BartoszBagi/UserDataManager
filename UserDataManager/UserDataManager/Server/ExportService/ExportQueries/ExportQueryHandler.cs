using ClosedXML.Excel;
using MediatR;
using System.Text.Json;
using UserDataManager.Shared.User.Models;

namespace UserDataManager.Server.ExportService.ExportQueries
{
    public class ExportQueryHandler : IRequestHandler<ExportQuery, byte[]>
    {
        public Task<byte[]> Handle(ExportQuery request, CancellationToken cancellationToken)
        {

            var usersData = JsonSerializer.Deserialize<List<UserVm>>(request.UsersDataAsJson);

            return Task.FromResult(CreateAuthorWorksheet(usersData));
        }

        private byte[] ConvertToByte(XLWorkbook workbook)
        {
            var stream = new MemoryStream();
            workbook.SaveAs(stream);

            var content = stream.ToArray();
            return content;
        }

        public byte[] CreateAuthorWorksheet(List<UserVm> usersData)
        {
            var package = new XLWorkbook();
            var worksheet = package.Worksheets.Add("Users");

            worksheet.Cell(1, 1).Value = "Id";
            worksheet.Cell(1, 2).Value = "Mr/Ms";
            worksheet.Cell(1, 3).Value = "Name";
            worksheet.Cell(1, 4).Value = "LastName";
            worksheet.Cell(1, 5).Value = "Age";
            for (int index = 1; index <= usersData.Count; index++)
            {
                worksheet.Cell(index + 1, 1).Value = usersData[index - 1].Id;
                if (usersData[index - 1].Gender == "male")
                    worksheet.Cell(index + 1, 2).Value = "Mr";
                else
                    worksheet.Cell(index + 1, 2).Value = "Ms";
                worksheet.Cell(index + 1, 3).Value = usersData[index - 1].Name;
                worksheet.Cell(index + 1, 4).Value = usersData[index - 1].LastName;
                worksheet.Cell(index + 1, 5).Value = AgeInYears(usersData[index - 1].BirthDate);
            }

            return ConvertToByte(package);
        }
        private int AgeInYears(DateTime bday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - bday.Year;
            if (bday.AddYears(age) > now)
                age--;
            return age;
        }
    }
}
