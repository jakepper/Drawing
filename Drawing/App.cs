using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Drawing.Components;
using Drawing.Commands;

namespace Drawing;

public class App : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
     private Input.KeyboardInput _keyboardInput = new();
    private readonly CommandFactory _commandFactory = new();
    private readonly Canvas _canvas = new();
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

        _commandFactory.Receiver = _canvas;

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

        _keyboardInput.Update(gameTime);

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
