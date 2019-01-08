using HelixToolkit.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace CandidateTest.Presentation.Wpf.Models
{
    internal sealed class ModelProvider : IModelProvider
    {
        private const int LineWith = 3;

        public Rect3D GetBounds(Model3D model) => model.Bounds;

        public Point3DCollection GetCenterOutLines(Rect3D rect)
        {
            Point3DCollection result = new Point3DCollection
            {
                new Point3D(rect.X + rect.SizeX, rect.Y + rect.SizeY / 2, rect.Z + rect.SizeZ / 2),
                new Point3D(rect.X + rect.SizeX + LineWith, rect.Y + rect.SizeY / 2, rect.Z + rect.SizeZ / 2),
                new Point3D(rect.X, rect.Y + rect.SizeY / 2, rect.Z + rect.SizeZ / 2),
                new Point3D(rect.X - LineWith, rect.Y + rect.SizeY / 2, rect.Z + rect.SizeZ / 2),
                new Point3D(rect.X + rect.SizeX / 2, rect.Y + rect.SizeY, rect.Z + rect.SizeZ / 2),
                new Point3D(rect.X + rect.SizeX / 2, rect.Y + rect.SizeY + LineWith, rect.Z + rect.SizeZ / 2),
                new Point3D(rect.X + rect.SizeX / 2, rect.Y, rect.Z + rect.SizeZ / 2),
                new Point3D(rect.X + rect.SizeX / 2, rect.Y - LineWith, rect.Z + rect.SizeZ / 2),
                new Point3D(rect.X + rect.SizeX / 2, rect.Y + rect.SizeY / 2, rect.Z + rect.SizeZ),
                new Point3D(rect.X + rect.SizeX / 2, rect.Y + rect.SizeY / 2, rect.Z + rect.SizeZ + LineWith),
                new Point3D(rect.X + rect.SizeX / 2, rect.Y + rect.SizeY / 2, rect.Z),
                new Point3D(rect.X + rect.SizeX / 2, rect.Y + rect.SizeY / 2, rect.Z - LineWith)
            };

            result.Freeze();

            return result;
        }

        private Model3D Load(string path)
        {
            Material material = new DiffuseMaterial(new SolidColorBrush(Colors.Beige));

            ModelImporter importer = new ModelImporter
            {
                DefaultMaterial = material
            };
            try
            {
                Model3D model = importer.Load(path);
                model.Freeze();
                return model;
            }
            catch (InvalidOperationException e)
            {
                throw new LoadException(e.Message);
            }
        }

        public Task<Model3D> LoadModelAsync(string path)
        {
            return Task.Factory.StartNew(() => Load(path), TaskCreationOptions.LongRunning);
        }
    }
}