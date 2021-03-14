using SharpGL;
using SharpGL.SceneGraph.Assets;
using SharpGL.SceneGraph.Cameras;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL.Enumerations;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Lighting;


namespace Planets_Lab_1
{
  public partial class Form1 : Form
  {
    SharpGL.SceneGraph.Quadrics.Sphere Earth = new SharpGL.SceneGraph.Quadrics.Sphere();
    SharpGL.SceneGraph.Quadrics.Sphere Moon = new SharpGL.SceneGraph.Quadrics.Sphere();
    SharpGL.SceneGraph.Quadrics.Sphere Sun = new SharpGL.SceneGraph.Quadrics.Sphere();
    SharpGL.SceneGraph.Quadrics.Sphere Mercury = new SharpGL.SceneGraph.Quadrics.Sphere();
    Texture texture = new Texture();

    

    public Form1()
    {
      InitializeComponent();

      OpenGL gl = sceneControl1.OpenGL;

      SharpGL.SceneGraph.Assets.Material SunMaterial = new SharpGL.SceneGraph.Assets.Material();
      SharpGL.SceneGraph.Assets.Material EarthMaterial = new SharpGL.SceneGraph.Assets.Material();
      SharpGL.SceneGraph.Assets.Material MoonMaterial = new SharpGL.SceneGraph.Assets.Material();
      SharpGL.SceneGraph.Assets.Material MercuryMaterial = new SharpGL.SceneGraph.Assets.Material();

      SharpGL.SceneGraph.Assets.Texture SunTexture = new SharpGL.SceneGraph.Assets.Texture();
      SharpGL.SceneGraph.Assets.Texture EarthTexture = new SharpGL.SceneGraph.Assets.Texture();
      SharpGL.SceneGraph.Assets.Texture MoonTexture = new SharpGL.SceneGraph.Assets.Texture();
      SharpGL.SceneGraph.Assets.Texture MercuryTexture = new SharpGL.SceneGraph.Assets.Texture();

      OpenGLControl openglCtr = new SharpGL.OpenGLControl();
      SunTexture.Create(openglCtr.OpenGL, "Sun.jpg");

      OpenGLControl openglCtr1 = new SharpGL.OpenGLControl();
      MoonTexture.Create(openglCtr1.OpenGL, "Moon.jpg");

      OpenGLControl openglCtr2 = new SharpGL.OpenGLControl();
      EarthTexture.Create(openglCtr2.OpenGL, "Earth.jpg");

      OpenGLControl openglCtr3 = new SharpGL.OpenGLControl();
      MercuryTexture.Create(openglCtr2.OpenGL, "Mercury.jpg");

      SunMaterial.Texture = SunTexture;
      Sun.TextureCoords = true;

      EarthMaterial.Texture = EarthTexture;
      Earth.TextureCoords = true;

      MoonMaterial.Texture = MoonTexture;
      Moon.TextureCoords = true;

      MercuryMaterial.Texture = MoonTexture;
      Mercury.TextureCoords = true;



      SunMaterial.Texture = SunTexture;

      Sun.Material = SunMaterial;
      Moon.Material = MoonMaterial;
      Earth.Material = EarthMaterial;
      Mercury.Material = MercuryMaterial;

      Earth.Radius = 2;
      Moon.Radius = 0.5;
      Sun.Radius = 4;
      Mercury.Radius = 0.7;

      sceneControl1.Scene.SceneContainer.AddChild(Earth);
      sceneControl1.Scene.SceneContainer.AddChild(Moon);
      sceneControl1.Scene.SceneContainer.AddChild(Sun);
      sceneControl1.Scene.SceneContainer.AddChild(Mercury);


      sceneControl1.Scene.RenderBoundingVolumes = !sceneControl1.Scene.RenderBoundingVolumes;

      Light light = new Light()
      {
        On = true,
        Position = new Vertex(0, 0, 0),
        GLCode = OpenGL.GL_LIGHT0
      };

      sceneControl1.Scene.SceneContainer.AddChild(light);

    }

    double rotate = 0;
    double i = 0;
    double j = 0;
    double k = 0;
    double s = 0;
    double m = 0;

    private void Tick(object sender, EventArgs e)
    {
      Earth.Transformation.RotateZ = (float) j;
      Moon.Transformation.RotateZ = (float) rotate;
      Sun.Transformation.RotateZ = (float) s;
      Mercury.Transformation.RotateZ = (float) m;

      Earth.Transformation.TranslateX = (float) (10 * Math.Cos(i));
      Earth.Transformation.TranslateY = (float) (10 * Math.Sin(i));


      Moon.Transformation.TranslateX = (float) (10 * Math.Cos(i)) + (float) (3 * Math.Cos(k));
      Moon.Transformation.TranslateY = (float) (10 * Math.Sin(i)) + (float) (3 * Math.Sin(k));

      Mercury.Transformation.TranslateX = (float) (5 * Math.Cos(m));
      Mercury.Transformation.TranslateY = (float) (5 * Math.Sin(m));

      k -= 0.005;
      j += 3;
      i += 0.0005;
      rotate -= 0.2;
      s += 0.01;
      m += 0.01;
    }

    

    private void button2_Click(object sender, EventArgs e)
    {
      OpenGL gl = this.sceneControl1.OpenGL;
      
      gl.LookAt(0, 0,0, -10, 10, -10, 1, 0, 0);
      
    }
  }
}
