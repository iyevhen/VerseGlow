using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

using NUnit.Framework;

namespace VerseGlow.Test.Core
{
	[TestFixture]
	public class SlideFixture
	{
		[Test]
		public void Slide_default_background_color()
		{
			Assert.AreEqual(Color.Black, new Slide().BackgroundColor);
		}

		[Test]
		public void Slide_default_forecolor()
		{
			Assert.AreEqual(Color.White, new Slide().ForeColor);
		}

		[Test]
		public void Slide_default_font()
		{
			Assert.AreEqual(SystemFonts.DefaultFont, new Slide().Font);
		}

		[Test]
		public void Slide_is_container_of_Layers()
		{
			var slide = new Slide();
			slide.AddLayer(NewLayer());
			slide.AddLayer(NewLayer());

			Assert.AreEqual(2, slide.LayersCount);
		}

		[Test]
		public void Cannot_add_same_layer_twice()
		{
			var slide = new Slide();
			SlideLayer layer = NewLayer();
			slide.AddLayer(layer);

			Assert.Throws<SlideException>(() => slide.AddLayer(layer));
		}

		[Test]
		public void Each_layer_is_ordered_on_the_slide()
		{
			var slide = new Slide();
			SlideLayer layer1 = NewLayer();
			SlideLayer layer2 = NewLayer();
			SlideLayer layer3 = NewLayer();
			slide.AddLayer(layer3);
			slide.AddLayer(layer1);
			slide.AddLayer(layer2);

			Assert.AreEqual(0, slide.IndexOf(layer3));
			Assert.AreEqual(1, slide.IndexOf(layer1));
			Assert.AreEqual(2, slide.IndexOf(layer2));

			Assert.AreSame(layer3, slide[0]);
			Assert.AreSame(layer1, slide[1]);
			Assert.AreSame(layer2, slide[2]);
		}

		[Test]
		public void Index_of_non_existing_layer()
		{
			Assert.AreEqual(-1, new Slide().IndexOf(NewLayer()));
		}

		[Test]
		public void Index_of_null_layer()
		{
			Assert.AreEqual(-1, new Slide().IndexOf(null));
		}

		[Test]
		public void Cannot_add_null_layer()
		{
			Assert.Throws<ArgumentNullException>(() => new Slide().AddLayer(null));
		}

		[Test]
		public void Can_move_layers_up()
		{
			var slide = new Slide();
			SlideLayer layer1 = NewLayer();
			SlideLayer layer2 = NewLayer();
			slide.AddLayer(layer1);
			slide.AddLayer(layer2);

			slide.MoveUp(layer1);

			Assert.AreSame(layer2, slide[0]);
			Assert.AreSame(layer1, slide[1]);
		}

		[Test]
		public void Check_arguments_on_move_up()
		{
			Assert.Throws<ArgumentNullException>(() => new Slide().MoveUp(null));
		}

		[Test]
		public void Cannot_move_up_nonexisting_layer()
		{
			Assert.Throws<SlideException>(() => new Slide().MoveUp(NewLayer()));
		}

		[Test]
		public void Move_up_one_layer()
		{
			var slide = new Slide();
			SlideLayer layer = NewLayer();
			slide.AddLayer(layer);
			slide.MoveUp(layer);
			slide.MoveUp(layer);
			slide.MoveUp(layer);

			Assert.AreSame(layer, slide[0]);
		}

		[Test]
		public void Can_move_layers_down()
		{
			var slide = new Slide();
			SlideLayer layer1 = NewLayer();
			SlideLayer layer2 = NewLayer();
			slide.AddLayer(layer1);
			slide.AddLayer(layer2);

			slide.MoveDown(layer2);

			Assert.AreSame(layer2, slide[0]);
			Assert.AreSame(layer1, slide[1]);
		}

		[Test]
		public void Check_arguments_on_move_down()
		{
			Assert.Throws<ArgumentNullException>(() => new Slide().MoveDown(null));
		}

		[Test]
		public void Cannot_move_down_nonexisting_layer()
		{
			Assert.Throws<SlideException>(() => new Slide().MoveDown(NewLayer()));
		}

		[Test]
		public void Move_down_one_layer()
		{
			var slide = new Slide();
			SlideLayer layer = NewLayer();
			slide.AddLayer(layer);
			slide.MoveDown(layer);
			slide.MoveDown(layer);
			slide.MoveDown(layer);

			Assert.AreSame(layer, slide[0]);
		}

		[Test]
		public void Can_remove_layer()
		{
			var slide = new Slide();
			slide.AddLayer(NewLayer());
			slide.RemoveLayer(slide[0]);
			Assert.AreEqual(0, slide.LayersCount);
		}

		private static SlideLayer NewLayer()
		{
			return new SlideLayerFoo();
		}
	}

	[Serializable]
	public class SlideException : Exception
	{
		public SlideException()
		{
		}

		public SlideException(string message)
			: base(message)
		{
		}

		public SlideException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected SlideException(
			SerializationInfo info,
			StreamingContext context)
			: base(info, context)
		{
		}
	}

	public class SlideLayerFoo : SlideLayer
	{
	}

	public interface SlideLayer
	{
	}

	public class Slide
	{
		private Color backgroundColor = Color.Black;
		private Color foreColor = Color.White;
		private Font font = SystemFonts.DefaultFont;
		private readonly List<SlideLayer> layers = new List<SlideLayer>();

		public Color BackgroundColor
		{
			get { return backgroundColor; }
			set { backgroundColor = value; }
		}

		public Color ForeColor
		{
			get { return foreColor; }
			set { foreColor = value; }
		}

		public Font Font
		{
			get { return font; }
			set { font = value; }
		}

		public int LayersCount
		{
			get { return layers.Count; }
		}

		public void AddLayer(SlideLayer layer)
		{
			if (layer == null)
				throw new ArgumentNullException("layer");

			if (Contains(layer))
				throw new SlideException("Cannot add same layer twice");

			layers.Add(layer);
		}

		public void RemoveLayer(SlideLayer layer)
		{
			layers.Remove(layer);
		}

		public SlideLayer this[int index]
		{
			get { return layers[index]; }
		}

		public bool Contains(SlideLayer layer)
		{
			return layers.Contains(layer);
		}

		public int IndexOf(SlideLayer layer)
		{
			return layers.IndexOf(layer);
		}

		public void MoveUp(SlideLayer layer)
		{
			if (layer == null)
				throw new ArgumentNullException("layer");

			int cur = IndexOf(layer);

			if (cur == -1)
				throw new SlideException("Layer is not present in current slide");

			int up = cur + 1;

			if (up == layers.Count)
				return;

			SlideLayer topper = layers[up];
			layers[cur] = topper;
			layers[up] = layer;
		}

		public void MoveDown(SlideLayer layer)
		{
			if (layer == null)
				throw new ArgumentNullException("layer");

			int cur = IndexOf(layer);

			if (cur == -1)
				throw new SlideException("Layer is not present in current slide");

			int down = cur - 1;

			if (down == -1)
				return;

			SlideLayer botom = layers[down];
			layers[cur] = botom;
			layers[down] = layer;
		}


	}
}
