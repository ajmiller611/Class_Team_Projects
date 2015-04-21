import java.awt.*;
import java.awt.event.*;
import java.awt.Graphics;

import javax.swing.*;

public class TSP_GA extends JFrame {
	private JPanel mainPanel, cityPanel, rightPanel, bottomPanel;
	private JTextField populationSize, mutationRate, maxGen;
	private JLabel titleLabel, populationSizeLabel, mutationRateLabel, maxGenLabel, initialDistanceLabel, initialDistanceValueLabel, solutionDistanceLabel, solutionDistanceValueLabel, numOfCitiesLabel, numOfCitiesValueLabel;
	private JButton startButton;
	JButton[][] grid;
	
	public TSP_GA() {
		super("Traveling Salesman GA");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(800,800);
		GridBagLayout layout = new GridBagLayout();
		setLayout(layout);
		GridBagConstraints gbc = new GridBagConstraints();
		
		mainPanel = new JPanel();
		mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.PAGE_AXIS));
		mainPanel.setMinimumSize(new Dimension(600, 633));
		mainPanel.setPreferredSize(new Dimension(600, 633));
		mainPanel.setBackground(Color.white);
		mainPanel.setBorder(BorderFactory.createLineBorder(Color.black));
		
		rightPanel = new JPanel();
		//rightPanel.setLayout(new BoxLayout(rightPanel, BoxLayout.PAGE_AXIS));
		rightPanel.setLayout(new FlowLayout(FlowLayout.CENTER, 100, 20));
		rightPanel.setMinimumSize(new Dimension(200, 800));
		rightPanel.setPreferredSize(new Dimension(200, 800));
		rightPanel.setBackground(Color.white);
		rightPanel.setBorder(BorderFactory.createLineBorder(Color.black));
		
		bottomPanel = new JPanel();
		bottomPanel.setMinimumSize(new Dimension(600, 166));
		bottomPanel.setPreferredSize(new Dimension(600, 166));
		bottomPanel.setBackground(Color.white);
		bottomPanel.setBorder(BorderFactory.createLineBorder(Color.black));
		
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
		
		JPanel test = new JPanel();
		test.setMaximumSize(new Dimension(600, 116));
		test.setBackground(Color.white);
		
		titleLabel = new JLabel("Traveling Salesman Problem using Genetic Algorithm");
		test.add(titleLabel);
		mainPanel.add(test);
		
		ButtonHandler handler = new ButtonHandler();
		
		populationSizeLabel = new JLabel("Population Size:");
		rightPanel.add(populationSizeLabel);
		
		populationSize = new JTextField();
		populationSize.setPreferredSize(new Dimension(100, 25));
		populationSize.setText("50");
		rightPanel.add(populationSize);
		
		maxGenLabel = new JLabel("Max Generations:");
		rightPanel.add(maxGenLabel);
		
		maxGen = new JTextField();
		maxGen.setPreferredSize(new Dimension(100, 25));
		maxGen.setText("10000");
		rightPanel.add(maxGen);
		
		mutationRateLabel = new JLabel("Mutation Rate:");
		rightPanel.add(mutationRateLabel);
		
		mutationRate = new JTextField();
		mutationRate.setPreferredSize(new Dimension(100, 25));
		mutationRate.setText("0.015");
		rightPanel.add(mutationRate);
		
		startButton = new JButton();
		startButton.setSize(50, 50);
		startButton.setText("Start");
		startButton.addActionListener(handler);
		rightPanel.add(startButton);

		
		
		
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
        
        numOfCitiesLabel = new JLabel("Number of Cities:");
		bottomPanel.add(numOfCitiesLabel);
		
		numOfCitiesValueLabel = new JLabel(TourManager.numberOfCities() + "");
		bottomPanel.add(numOfCitiesValueLabel);
		
		initialDistanceLabel = new JLabel("Initial Tour Distance:");
		bottomPanel.add(initialDistanceLabel);
		
		initialDistanceValueLabel = new JLabel();
		bottomPanel.add(initialDistanceValueLabel);
		
		solutionDistanceLabel = new JLabel("Solution Tour Distance:");
		bottomPanel.add(solutionDistanceLabel);
		
		solutionDistanceValueLabel = new JLabel();
		bottomPanel.add(solutionDistanceValueLabel);
        
        
        Tour initialTour = new Tour();
        for (int i = 0; i < TourManager.numberOfCities(); i++) {
        	initialTour.setCity(i, TourManager.getCity(i));
        }
        cityPanel = new drawStartingCities(initialTour);
        mainPanel.add(cityPanel);
		
		setVisible(true);
	}
	
	public static void main(String[] args)
	{
		new TSP_GA();
	}
	
	public class ButtonHandler implements ActionListener
	{
		public void actionPerformed(ActionEvent e)
		{
			if (e.getSource() == startButton) {
				Population pop = new Population(Integer.parseInt(populationSize.getText()), true);
				System.out.println("Initial distance: " + pop.getFittest().getDistance());
				initialDistanceValueLabel.setText(pop.getFittest().getDistance() + "");
				
				GA.setMutationRate(Double.parseDouble(mutationRate.getText()));
				
				pop = GA.evolvePopulation(pop);
				for (int i = 0; i < Integer.parseInt(maxGen.getText()); i ++)
				{
					pop = GA.evolvePopulation(pop);
				}
				
				solutionDistanceValueLabel.setText(pop.getFittest().getDistance() + "");
				
				mainPanel.remove(cityPanel);
				cityPanel = new drawCities(pop.getFittest());

				mainPanel.add(cityPanel);
				mainPanel.validate();
				repaint();
				System.out.println("Finished");
				System.out.println("Final distance: " + pop.getFittest().getDistance());
				System.out.println("Solution:");
				System.out.println(pop.getFittest());
			}
		}
	}
}
