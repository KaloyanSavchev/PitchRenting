using PitchRentingSystem.Web.Models.Pitches;

namespace PitchRentingSystem.Web
{
    public class Common
    {
        public static IEnumerable<PitchesDetailsViewModel> GetPitches() 
            => new List<PitchesDetailsViewModel>()
            {
                new PitchesDetailsViewModel
                {
                    Title = "Camp Nou",
                    Address = "Camp Nou Football Stadium",
                    ImageUrl = "https://www.fcbarcelona.com/photo-resources/2020/02/24/3f1215ed-07e8-47ef-b2c7-8a519f65b9cd/mini_UP3_20200105_FCB_VIS_View_1a_Empty.jpg?width=1200&height=750"
                },

                new PitchesDetailsViewModel
                {
                    Title = "Maracanã Stadium",
                    Address = "R. Prof. Eurico Rabelo - Maracanã, Rio de Janeiro",
                    ImageUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/0d/e0/b7/00/maracana-stadion.jpg?w=1200&h=-1&s=1"
                },

                new PitchesDetailsViewModel
                {
                    Title = "Santiago Bernabéu Stadium",
                    Address = "Av. de Concha Espina, 1, Chamartín",
                    ImageUrl = "https://estaticos.esmadrid.com/cdn/farfuture/wwgUeNPLBq8Z-HJOYcUUx_8t1mXAr0eYBgMKLjFy1p4/mtime:1710755365/sites/default/files/styles/content_type_full/public/recursosturisticos/infoturistica/bernabeu.jpg?itok=KvMJw4Dh"
                }
            };

    }
}
