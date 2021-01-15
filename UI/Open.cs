using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
namespace BossScale.UI
{
    internal class Open : UIState
    {

        public override void OnInitialize()
        {
            UIPanel panel = new UIPanel();
            panel.Width.Set(60, 0);
            panel.Height.Set(30, 0);
            panel.Left.Set(-panel.Width.Pixels - 1470, 1f);
            panel.OnClick += OnButtonClick;
            panel.Top.Set(800, 0f);
            Append(panel);

        
            UIText text = new UIText("Scale"); //all of this code is horrendesly broken.
            text.HAlign = text.VAlign = 0.5f; 
            panel.Append(text);      }

        private void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            ModContent.GetInstance<BossScale>().ShowMyUI();
        }
    }
}