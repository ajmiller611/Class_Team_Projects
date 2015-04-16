import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class TSP_GA extends JFrame {
	private JPanel mainPanel, rightPanel, bottomPanel;
	private JTextField populationSize, mutationRate, maxGen;
	private JLabel titleLabel, populationSizeLabel, mutationRateLabel, maxGenLabel, lastIterLabel, lastIterValueLabel, lastTourLengthLabel, lastTourLengthValueLabel, numOfCitesLabel, numOfCitesValueLabel;
	private JButton startButton;
	
	public TSP_GA() {
		super("Traveling Salesman GA");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(800,800);
		GridBagLayout layout = new GridBagLayout();
		setLayout(layout);
		GridBagConstraints gbc = new GridBagConstraints();
		
		mainPanel = new JPanel();
		mainPanel.setMinimumSize(new Dimension(600, 633));
		mainPanel.setPreferredSize(new Dimension(600, 633));
		mainPanel.setBackground(Color.black);
		
		rightPanel = new JPanel();
		rightPanel.setMinimumSize(new Dimension(200, 800));
		rightPanel.setPreferredSize(new Dimension(200, 800));
		rightPanel.setBackground(Color.blue);
		
		bottomPanel = new JPanel();
		bottomPanel.setMinimumSize(new Dimension(600, 166));
		bottomPanel.setPreferredSize(new Dimension(600, 166));
		bottomPanel.setBackground(Color.green);
		
		gbc.gridx = 0;
		gbc.gridy = 0;
		gbc.gridwidth = 3;
		gbc.gridheight = 2;
		//gbc.fill = GridBagConstraints.BOTH;
		add(mainPanel, gbc);
		
		gbc.gridx = 4;
		gbc.gridy = 1;
		gbc.gridheight = 2;
		//gbc.fill = GridBagConstraints.BOTH;
		add(rightPanel, gbc);
		
		gbc.gridx = 0;
		gbc.gridy = 2;
		gbc.gridwidth = 3;
		gbc.weighty = 1.0;
		//gbc.fill = GridBagConstraints.SOUTH;
		add(bottomPanel, gbc);
		
		setVisible(true);
		
		City city = new City(60, 200);
        TourManager.addCity(city);
        City city2 = new City(180, 200);
        TourManager.addCity(city2);
        City city3 = new City(80, 180);
        TourManager.addCity(city3);
        City city4 = new City(140, 180);
        TourManager.addCity(city4);
        City city5 = new City(20, 160);
        TourManager.addCity(city5);
        City city6 = new City(100, 160);
        TourManager.addCity(city6);
        City city7 = new City(200, 160);
        TourManager.addCity(city7);
        City city8 = new City(140, 140);
        TourManager.addCity(city8);
        City city9 = new City(40, 120);
        TourManager.addCity(city9);
        City city10 = new City(100, 120);
        TourManager.addCity(city10);
        City city11 = new City(180, 100);
        TourManager.addCity(city11);
        City city12 = new City(60, 80);
        TourManager.addCity(city12);
        City city13 = new City(120, 80);
        TourManager.addCity(city13);
        City city14 = new City(180, 60);
        TourManager.addCity(city14);
        City city15 = new City(20, 40);
        TourManager.addCity(city15);
        City city16 = new City(100, 40);
        TourManager.addCity(city16);
        City city17 = new City(200, 40);
        TourManager.addCity(city17);
        City city18 = new City(20, 20);
        TourManager.addCity(city18);
        City city19 = new City(60, 20);
        TourManager.addCity(city19);
        City city20 = new City(160, 20);
        TourManager.addCity(city20);

		Population pop = new Population(5, true);
		System.out.println("Initial distance: " + pop.getFittest().getDistance());
		
		pop = GA.evolvePopulation(pop);
		for (int i = 0; i < 100; i ++)
		{
			pop = GA.evolvePopulation(pop);
		}
		
		System.out.println("Finished");
		System.out.println("Final distance: " + pop.getFittest().getDistance());
		System.out.println("Solution:");
		System.out.println(pop.getFittest());
	}
	public static void main(String[] args)
	{
		new TSP_GA();
	}
}
