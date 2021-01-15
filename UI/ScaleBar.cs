
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace BossScale.UI
{
    internal class ScaleBar : UIState
    {
        private UIText text;
        private UIElement area;
        private UIImage ScaleFrame;
        private Color gradientA;
        private Color gradientB;

        public override void OnInitialize()
        {


            area = new UIElement();

            area.Left.Set(-area.Width.Pixels - 600, 1f);
            area.Top.Set(30, 0f);
            area.Width.Set(182, 0f);
            area.Height.Set(180, 0f);
            ScaleFrame = new UIImage(ModContent.GetTexture("BossScale/UI/ScaleFrame"));
            ScaleFrame.Left.Set(22, 0f);
            ScaleFrame.Top.Set(0, 0f);
            ScaleFrame.Width.Set(138, 0f);
            ScaleFrame.Height.Set(34, 0f);
            text = new UIText("0/0", 0.8f);
            text.Width.Set(138, 0f);
            text.Height.Set(34, 0f);
            text.Top.Set(40, 0f);
            text.Left.Set(0, 0f);
            gradientA = new Color(48, 219, 42);
            gradientB = new Color(219, 57, 29);
            area.Append(text);
            area.Append(ScaleFrame);
            Append(area);

            #region buttons

            UIPanel button = new UIPanel();
            button.Width.Set(80, 0);
            button.Height.Set(40, 0);
            button.VAlign = 0.5f;
            button.HAlign = 0.1f;
            button.Top.Set(25, 0);
            button.OnClick += OnButtonClick;
            area.Append(button);

            UIPanel button2 = new UIPanel();
            button2.Width.Set(80, 0);
            button2.Height.Set(40, 0);
            button2.VAlign = 0.5f;
            button2.HAlign = 0.9f;
            button2.Top.Set(25, 0);
            button2.OnClick += OnButtonClick2;
            area.Append(button2);

            UIPanel button3 = new UIPanel();
            button3.Width.Set(80, 0);
            button3.Height.Set(40, 0);
            button3.VAlign = 0.9f;
            button3.HAlign = 0.1f;
            button3.Top.Set(25, 0);
            button3.OnClick += OnButtonClick3;
            area.Append(button3);

            UIPanel button4 = new UIPanel();
            button4.Width.Set(80, 0);
            button4.Height.Set(40, 0);
            button4.VAlign = 0.9f;
            button4.HAlign = 0.9f;
            button4.Top.Set(25, 0);
            button4.OnClick += OnButtonClick4;
            area.Append(button4);

            UIText text2 = new UIText("+ 0.1");
            button.Append(text2);
            UIText text3 = new UIText("+ 1.0");
            button2.Append(text3);
            UIText text4 = new UIText("- 0.1");
            button3.Append(text4);
            UIText text5 = new UIText("- 1.0");
            button4.Append(text5);
            #endregion
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            float quotient = ((float)((float)bossmult.bossmults / bossmult.max));
            quotient = Utils.Clamp(quotient, 0f, 1f);
            Rectangle hitbox = ScaleFrame.GetInnerDimensions().ToRectangle();
            hitbox.X += 12;
            hitbox.Width -= 24;
            hitbox.Y += 8;
            hitbox.Height -= 16;
            int left = hitbox.Left;
            int right = hitbox.Right;
            int steps = (int)((right - left) * quotient);
            for (int i = 0; i < steps; i += 1)
            {
                float percent = (float)i / (right - left);
                spriteBatch.Draw(Main.magicPixel, new Rectangle(left + i, hitbox.Y, 1, hitbox.Height), Color.Lerp(gradientA, gradientB, percent));
            }
        }
        public override void Update(GameTime gameTime)
        {
            text.SetText($"Multiplier: {bossmult.bossmults} / {bossmult.max}");
            base.Update(gameTime);
        }
        #region button functions
        private void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            bossmult.bossmults += 0.1;
            Main.PlaySound(SoundID.MenuOpen);
        }
        private void OnButtonClick2(UIMouseEvent evt, UIElement listeningElement)
        {
            bossmult.bossmults += 1.0;
            Main.PlaySound(SoundID.MenuOpen);
        }
        private void OnButtonClick3(UIMouseEvent evt, UIElement listeningElement)
        {
            if (bossmult.bossmults >= 0.2)
            {
                bossmult.bossmults -= 0.1;
                Main.PlaySound(SoundID.MenuOpen);
            }
            else
            {
                bossmult.bossmults = 0.1;
                Main.PlaySound(SoundID.MaxMana);
            }
        }
        private void OnButtonClick4(UIMouseEvent evt, UIElement listeningElement)
        {
            if (bossmult.bossmults >= 0.2)
            {
                bossmult.bossmults -= 1.0;
                Main.PlaySound(SoundID.MenuOpen);
            }
            else
            {
                bossmult.bossmults = 0.1;
                Main.PlaySound(SoundID.MaxMana);
            }
        }
        #endregion

        public override void ScrollWheel(UIScrollWheelEvent evt)
        {

            if (ScaleFrame.IsMouseHovering)
            {
                if (PlayerInput.ScrollWheelDelta < 0)
                {
                    if (bossmult.bossmults >= 0.2)
                    {
                        bossmult.bossmults -= 0.1;
                    }
                }
                if (PlayerInput.ScrollWheelDelta > 0)
                {
                    bossmult.bossmults += 0.1;
                }
            }
        }

    }
}