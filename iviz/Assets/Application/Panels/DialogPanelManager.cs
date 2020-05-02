﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Iviz.App
{
    public enum DialogPanelType
    {
        ItemList
    }

    public class DialogPanelManager : MonoBehaviour
    {
        readonly Dictionary<DialogPanelType, IDialogPanelContents> PanelByType = new Dictionary<DialogPanelType, IDialogPanelContents>();

        DialogData SelectedDialogData;
        Canvas parentCanvas;
        bool started;

        public bool Active
        {
            get => parentCanvas.enabled;
            set
            {
                parentCanvas.enabled = value;
            }
        }

        void Awake()
        {
            parentCanvas = GetComponentInParent<Canvas>();

            gameObject.SetActive(false);
            PanelByType[DialogPanelType.ItemList] = CreateItemPanelObject("Dialog Item Panel").GetComponent<DialogItemList>();
            Active = false;
            gameObject.SetActive(true);
            started = true;

            GameThread.EverySecond += UpdateSelected;
        }

        void OnDestroy()
        {
            GameThread.EverySecond -= UpdateSelected;
        }

        void UpdateSelected()
        {
            SelectedDialogData?.UpdatePanel();
        }

        public IDialogPanelContents GetPanelByType(DialogPanelType resource)
        {
            return PanelByType.TryGetValue(resource, out IDialogPanelContents cm) ? cm : null;
        }

        public void SelectPanelFor(DialogData newSelected)
        {
            if (!started)
            {
                return;
            }
            if (newSelected == SelectedDialogData)
            {
                return;
            }
            HideSelectedPanel();
            if (newSelected != null)
            {
                ShowPanel(newSelected);
            }
        }

        void ShowPanel(DialogData newSelected)
        {
            SelectedDialogData = newSelected;
            SelectedDialogData.SetupPanel();
            SelectedDialogData.Panel.Active = true;
            Active = true;
        }

        public void HideSelectedPanel()
        {
            if (SelectedDialogData == null)
            {
                return;
            }

            SelectedDialogData.Panel.Active = false;
            SelectedDialogData.CleanupPanel();
            SelectedDialogData.Panel.ClearSubscribers();
            SelectedDialogData = null;
            Active = false;
        }


        public void HidePanelFor(DialogData deselected)
        {
            if (SelectedDialogData == deselected)
            {
                HideSelectedPanel();
            }
        }

        public void TogglePanel(DialogData selected)
        {
            if (SelectedDialogData == selected)
            {
                HideSelectedPanel();
            }
            else
            {
                SelectPanelFor(selected);
            }
        }


        GameObject CreateItemPanelObject(string name)
        {
            GameObject o = Instantiate(Resources.Load<GameObject>("Widgets/Item List Panel"), transform);
            o.name = name;
            return o;
        }
    }
}