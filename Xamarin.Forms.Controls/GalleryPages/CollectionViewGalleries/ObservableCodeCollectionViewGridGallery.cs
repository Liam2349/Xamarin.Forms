﻿namespace Xamarin.Forms.Controls.GalleryPages.CollectionViewGalleries
{
	internal class ObservableCodeCollectionViewGallery : ContentPage
	{
		public ObservableCodeCollectionViewGallery(ItemsLayoutOrientation orientation = ItemsLayoutOrientation.Vertical,
			bool grid = true, bool empty = false, bool addItemsWithTimer = false)
		{
			var layout = new Grid
			{
				RowDefinitions = new RowDefinitionCollection
				{
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Star }
				}
			};

			IItemsLayout itemsLayout = grid
				? new GridItemsLayout(3, orientation)
				: new ListItemsLayout(orientation) as IItemsLayout;

			var itemTemplate = ExampleTemplates.PhotoTemplate();

			var collectionView = new CollectionView { ItemsLayout = itemsLayout, ItemTemplate = itemTemplate };

			var generator = new ItemsSourceGenerator(collectionView, empty ? 0 : 1000);

			var remover = new ItemRemover(collectionView);
			var inserter = new ItemInserter(collectionView);
			var replacer = new ItemReplacer(collectionView);
			var mover = new ItemMover(collectionView);
			var adder = new ItemAdder(collectionView);

			layout.Children.Add(generator);

			layout.Children.Add(remover);
			Grid.SetRow(remover, 1);

			layout.Children.Add(inserter);
			Grid.SetRow(inserter, 2);

			layout.Children.Add(replacer);
			Grid.SetRow(replacer, 3);

			layout.Children.Add(mover);
			Grid.SetRow(mover, 4);

			layout.Children.Add(adder);
			Grid.SetRow(adder, 5);

			layout.Children.Add(collectionView);
			Grid.SetRow(collectionView, 6);

			Content = layout;
			if (addItemsWithTimer)
				generator.GenerateEmptyObservableCollectionAndAddItemsEverySecond();
			else
				generator.GenerateObservableCollection();
		}
	}
}