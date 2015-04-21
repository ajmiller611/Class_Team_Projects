	import java.awt.Color;
	import java.awt.Dimension;
	import java.awt.Graphics;

	import javax.swing.JPanel;

	public class drawStartingCities extends JPanel {
		Tour tourObj = new Tour();
		
		public drawStartingCities(Tour tour) {
			setMinimumSize(new Dimension(410,410));
			setPreferredSize(new Dimension(410,410));
			setMaximumSize(new Dimension(410,410));
			setBackground(Color.white);
			tourObj = tour;			
		}
		
		public void paintComponent(Graphics g) {
			super.paintComponent(g);
			
			g.setColor(Color.black);
			for (int i = 0; i < tourObj.tourSize(); i++) {
				City currentCity = tourObj.getCity(i);
				g.fillOval((200 - currentCity.getX()) * 2, (200 - currentCity.getY()) * 2, 10, 10);
			}
		}
	}
