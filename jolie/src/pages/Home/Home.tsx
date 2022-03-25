import React from 'react';

import { Helmet } from 'react-helmet';
import { useNavigate } from 'react-router-dom';
import { isMobile, openURL } from 'util/screen';

import Button from 'components/Button/Button';
import Slider from 'components/Slider/Slider';

import logo from 'assets/icons/logo.png';

import hetimiul_1 from 'assets/images/hetimiul_1.png';
import hetimiul_2 from 'assets/images/hetimiul_2.png';
import hetimiul_3 from 'assets/images/hetimiul_3.png';

import cisius_1 from 'assets/images/cisius_1.png';
import cisius_2 from 'assets/images/cisius_2.png';
import cisius_3 from 'assets/images/cisius_3.png';

import juseno_1 from 'assets/images/juseno_1.png';
import juseno_2 from 'assets/images/juseno_2.png';
import juseno_3 from 'assets/images/juseno_3.png';

import classes from './Home.module.scss';

const Home: React.FC = () => {
	const navigate = useNavigate();

	return (
		<>
			<Helmet>
				<title>Home | Weebin</title>
			</Helmet>

			<div className={classes.Main}>
				<img className={classes.Logo} src={logo} alt='Weebin Logo' />

				<div className={classes.Container}>
					<div className={classes.Sliders}>
						<Slider className={classes.Slider} data={[hetimiul_1, hetimiul_2, hetimiul_3]} delay={2} />
						<Slider className={classes.Slider} data={[cisius_1, cisius_2, cisius_3]} delay={4} />
						<Slider className={classes.Slider} data={[juseno_1, juseno_2, juseno_3]} />
					</div>

					<div className={classes.Actions}>
						{!isMobile() && (
							<Button onClick={() => navigate('/play')} className={classes.Play}>
								Play
							</Button>
						)}

						<Button onClick={() => openURL('https://mivladie.github.io/gato/')}>Gato</Button>
						<Button onClick={() => openURL('https://github.com/MiVladie/weebin', true)}>GitHub</Button>
					</div>
				</div>
			</div>
		</>
	);
};

export default Home;
