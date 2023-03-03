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
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private readonly InputHandler _inputHandler = new();
    private Menu _menu;
    private Canvas _canvas;
    private string _selectedResource;
    private float _currentScale = 1.0F;

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

        CommandFactory.Receiver = _canvas;

        int menuWidth = (int) WIDTH / 8;

        _menu = new(new Vector2(0, 0), menuWidth, HEIGHT);
        _canvas = new(new Vector2(menuWidth, 0), WIDTH - menuWidth, HEIGHT);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        ComponentFactory.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _inputHandler.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        if (_canvas != null) _canvas.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
