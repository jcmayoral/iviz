﻿using Iviz.App.Listeners;
using Iviz.Resources;
using UnityEngine;

namespace Iviz.App
{
    public class OccupancyGridDisplayData : ListenerDisplayData
    {
        readonly OccupancyGridListener listener;
        readonly OccupancyGridPanelContents panel;

        protected override TopicListener Listener => listener;

        public override DataPanelContents Panel => panel;
        public override Resource.Module Module => Resource.Module.OccupancyGrid;
        public override IConfiguration Configuration => listener.Config;


        public OccupancyGridDisplayData(DisplayDataConstructor constructor) :
        base(constructor.DisplayList,
            constructor.GetConfiguration<OccupancyGridConfiguration>()?.Topic ?? constructor.Topic, constructor.Type)
        {
            panel = DataPanelManager.GetPanelByResourceType(Resource.Module.OccupancyGrid) as OccupancyGridPanelContents;
            listener = Resource.Listeners.Instantiate<OccupancyGridListener>();
            listener.name = "OccupancyGrid:" + Topic;
            listener.DisplayData = this;
            if (constructor.Configuration == null)
            {
                listener.Config.Topic = Topic;
            }
            else
            {
                listener.Config = (OccupancyGridConfiguration)constructor.Configuration;
            }
            listener.StartListening();
            UpdateButtonText();
        }

        public override void SetupPanel()
        {
            panel.Listener.RosListener = listener.Listener;

            panel.Colormap.Index = (int)listener.Colormap;
            panel.HideButton.State = listener.Visible;
            panel.FlipColors.Value = listener.FlipColors;
            panel.ScaleZ.Value = listener.ScaleZ;

            panel.FlipColors.ValueChanged += f =>
            {
                listener.FlipColors = f;
            };
            panel.ScaleZ.ValueChanged += f =>
            {
                listener.ScaleZ = f;
            };

            panel.Colormap.ValueChanged += (i, _) =>
            {
                listener.Colormap = (Resource.ColormapId)i;
            };
            panel.CloseButton.Clicked += () =>
            {
                DataPanelManager.HideSelectedPanel();
                DisplayListPanel.RemoveDisplay(this);
            };
            panel.HideButton.Clicked += () =>
            {
                listener.Visible = !listener.Visible;
                panel.HideButton.State = listener.Visible;
                UpdateButtonText();
            };
        }

        public override void AddToState(StateConfiguration config)
        {
            config.OccupancyGrids.Add(listener.Config);
        }
    }
}
