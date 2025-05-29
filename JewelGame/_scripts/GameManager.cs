using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewelGame._Scripts
{

    internal class GameManager
    {
        private JewelGrid _jewelGrid;

        private Player _player1;
        private Player _player2;
        private ProgressBar _player1HPBar;
        private ProgressBar _player2HPBar;
        public bool _isPlayer1Turn = true;
        private int a = 0, b = 0;

        private Panel _player1Sbar;
        private Panel _player2Sbar;
        private Panel _player1Cbar;
        private Panel _player2Cbar;

        public int[] LastResult { get; private set; }

        public GameManager(JewelGrid jewelGrid)
        {
            _jewelGrid = jewelGrid;

            _player1 = GameContext.Player1;
            _player2 = GameContext.Player2;
            _player1HPBar = GameContext.Player1HPBar;
            _player2HPBar = GameContext.Player2HPBar;
            _player1Sbar = GameContext.Player1Sbar;
            _player2Sbar = GameContext.Player2Sbar;
            _player1Cbar = GameContext.Player1Cbar;
            _player2Cbar = GameContext.Player2Cbar;

            _jewelGrid._OnEndTurn += _OnEndTurn;
        }

        private void _OnEndTurn(int[] result)
        {
            int damage = result[0] * 7;
            int heal = result[1] * 5;
            int shield = result[2];
            int buff = result[3] * 3;
            int control = result[4];

            _jewelGrid.BeginInvoke((Action)(() =>
            {

                if (_isPlayer1Turn)
                {
                    _player1.TakeShield(shield + buff / 6);
                    _player2.TakeDamage(damage + buff);
                    _player1.takeHealth(heal + buff);
                    _player1.Control(control + buff / 6);

                    _player1HPBar.Value = _player1.HP;
                    _player2HPBar.Value = _player2.HP;
                    Update(_player1Cbar, _player1.controlMana);

                    Update(_player2Sbar, _player2.Shield);
                    Update(_player1Sbar, _player1.Shield);
                }
                else
                {
                    _player2.TakeShield(shield + buff / 6);
                    _player1.TakeDamage(damage + buff);
                    _player2.takeHealth(heal + buff);
                    _player2.Control(control + buff / 6);

                    _player1HPBar.Value = _player1.HP;
                    _player2HPBar.Value = _player2.HP;
                    Update(_player2Cbar, _player2.controlMana);
                    Update(_player1Sbar, _player1.Shield);
                    Update(_player2Sbar, _player2.Shield);
                }

                if (_isPlayer1Turn && _player1.isControl)
                {
                    _player1.isControl = false;
                    MessageBox.Show(_player1.Name.TrimEnd() + " bị khống chế, không thể hành động");
                }
                else if (!_isPlayer1Turn && _player2.isControl)
                {
                    _player2.isControl = false;
                    MessageBox.Show(_player1.Name.TrimEnd() + " bị khống chế, không thể hành động");
                }
                else
                {
                    _isPlayer1Turn = !_isPlayer1Turn; // đổi lượt bình thường
                }
                a++;

                string nextPlayerName = _isPlayer1Turn ? _player1.Name : _player2.Name;
                MessageBox.Show("Đến lượt " + nextPlayerName);

                if (_player1.IsDefeated())
                {
                    MessageBox.Show(_player2.Name + " chiến thắng!");
                    Application.Exit();
                    return;
                }
                else if (_player2.IsDefeated())
                {
                    MessageBox.Show(_player1.Name + " chiến thắng!");
                    Application.Exit();
                    return;
                }
            }));
        }
        public void Update(Panel panelCover, int curentPanel)
        {
            int maxMana = 10;
            int fullWidth = panelCover.Parent.Width;

            float ratio = (float)(maxMana - curentPanel) / maxMana;
            panelCover.Width = (int)(fullWidth * ratio);
        }
        public bool playerTurn()
        {
            return _isPlayer1Turn;
        }
    }
}

