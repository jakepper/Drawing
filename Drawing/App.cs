using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Drawing.Components;
using Drawing.Commands;
using Drawing.Input;

namespace Drawing;

public class App : Game
{
    private const int WIDTH = 1600;
    private const int HEIGHT = 900;
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _blankTexture;
    private InputHandler _inputHandler;
    private Menu _menu;
    private Canvas _canvas;

    public App()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 1600;
        _graphics.PreferredBackBufferHeight = 900;
        _graphics.ApplyChanges();

        _blankTexture = new Texture2D(GraphicsDevice, 1, 1);
        _blankTexture.SetData(new[] { Color.White });

        ComponentFactory.LoadContent(Content);

        int menuWidth = (int) WIDTH / 8;
        _menu = new(new Vector2(0, 0), menuWidth, HEIGHT, _blankTexture);
        
        _canvas = new(new Vector2(menuWidth, 0), WIDTH - menuWidth, HEIGHT, _blankTexture);
        CommandFactory.Receiver = _canvas;

        _inputHandler = new(_menu);
        _inputHandler.RegisterKeyboardCommand(Keys.F1, true, CommandFactory.CommandType.NEW);
        _inputHandler.RegisterKeyboardCommand(Keys.F2, true, CommandFactory.CommandType.DESELECT);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _inputHandler.Update(gameTime);
        Invoker.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _menu?.Draw(_spriteBatch);
        _canvas?.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
