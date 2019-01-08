using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace CandidateTest.Presentation.Wpf.Models
{
    internal interface IModelProvider
    {
        Rect3D GetBounds(Model3D model);
        Point3DCollection GetCenterOutLines(Rect3D bounds);
        Task<Model3D> LoadModelAsync(string path);
    }
}